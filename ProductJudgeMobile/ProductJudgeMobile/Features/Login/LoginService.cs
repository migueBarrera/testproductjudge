using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Auth;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Refit;
using SecretAligner.Telemedicine.Mobile.Infrastructure;
using System.Net.Http.Headers;

namespace ProductJudgeMobile.Features.Login;

public class LoginService
{
    private readonly IAuthApi authApi;
    private readonly ILogger<LoginService> logger;

    public LoginService(ILogger<LoginService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        authApi = Refit.RestService.For<IAuthApi>(httpClient);
    }

    internal async Task<ApiResultResponse> Login(string username, string password)
    {
        try
        {
            var response = await authApi.Login(new LoginRequestDto
            {
                Email = username,
                Password = password
            });

            if (response == null)
            {
                return ApiResultResponse.CreateError("Invalid username or password");
            }

            // Save token to secure storage
            await SecureStorage.SetAsync("token", response.Token);

            return ApiResultResponse.CreateSuccess();
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse.CreateError("Invalid username or password");
        }
    }
}
