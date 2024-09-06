using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ProductJudge.Mobile.DAL.Refit;

public class HttpLoggingHandler : DelegatingHandler
{
    private readonly ILogger<HttpLoggingHandler> logger;
    private readonly string[] types = { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

    public HttpLoggingHandler(ILogger<HttpLoggingHandler> logger, HttpMessageHandler? innerHandler = null)
        : base(innerHandler ?? new HttpClientHandler())
    {
        this.logger = logger;
    }

    async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var req = request;
        var id = Guid.NewGuid().ToString();
        var msg = $"[{id} -   Request]";

        logger.LogInformation($"{msg} ========Start==========");
        logger.LogInformation($"{msg} {req.Method} {req?.RequestUri?.PathAndQuery} {req?.RequestUri?.Scheme}/{req?.Version}");
        logger.LogInformation($"{msg} Host: {req?.RequestUri?.Scheme}://{req?.RequestUri?.Host}");

        foreach (var header in req?.Headers ?? default!)
        {
            logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
        }

        if (req?.Content != null)
        {
            foreach (var header in req.Content.Headers)
            {
                logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
            }

            if (req.Content is StringContent || IsTextBasedContentType(req.Headers) || IsTextBasedContentType(req.Content.Headers))
            {
                var result = await req.Content.ReadAsStringAsync();

                logger.LogInformation($"{msg} Content:");
                logger.LogInformation($"{msg} {string.Join(string.Empty, result.Cast<char>())}...");
            }
        }

        var stopwatch = Stopwatch.StartNew(); // Usar Stopwatch en lugar de DateTime para medir el tiempo

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        stopwatch.Stop();

        logger.LogInformation($"{msg} Duration: {stopwatch.Elapsed}");
        logger.LogInformation($"{msg} ==========End==========");

        msg = $"[{id} - Response]";
        logger.LogInformation($"{msg} =========Start=========");

        var resp = response;

        logger.LogInformation($"{msg} {req?.RequestUri?.Scheme.ToUpper()}/{resp.Version} {(int)resp.StatusCode} {resp.ReasonPhrase}");

        foreach (var header in resp.Headers)
        {
            logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
        }

        if (resp.Content != null)
        {
            foreach (var header in resp.Content.Headers)
            {
                logger.LogInformation($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
            }

            if (resp.Content is StringContent || IsTextBasedContentType(resp.Headers) || IsTextBasedContentType(resp.Content.Headers))
            {
                stopwatch.Restart(); // Reiniciar el Stopwatch para medir el tiempo de lectura del contenido
                var result = await resp.Content.ReadAsStringAsync();
                stopwatch.Stop();

                logger.LogInformation($"{msg} Content:");
                logger.LogInformation($"{msg} {string.Join(string.Empty, result.Cast<char>())}...");
                logger.LogInformation($"{msg} Duration: {stopwatch.Elapsed}");
            }
        }

        logger.LogInformation($"{msg} ==========End==========");
        return response;
    }

    private bool IsTextBasedContentType(HttpHeaders headers)
    {
        if (headers.TryGetValues("Content-Type", out IEnumerable<string>? values))
        {
            var header = string.Join(" ", values).ToLowerInvariant();
            return types.Any(t => header.Contains(t));
        }

        return false;
    }
}
