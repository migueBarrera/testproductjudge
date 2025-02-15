using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Auth;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Refit;
using SecretAligner.Telemedicine.Mobile.Infrastructure;

namespace ProductJudgeMobile.Features.Register;

public class RegisterService
{
    private readonly IAuthApi authApi;
    private readonly ILogger<RegisterService> logger;

    public RegisterService(ILogger<RegisterService> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;

        var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
        authApi = Refit.RestService.For<IAuthApi>(httpClient);
    }

    internal async Task<ApiResultResponse> Register(string username,string email, string password)
    {
        try
        {
            logger.LogError("test");
            var response = await authApi.Register(new RegisterRequestDto
            {
                Email = email,
                Password = password,
                Name = username
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
