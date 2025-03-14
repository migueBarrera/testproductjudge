using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Auth;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Helpers;
using System.Net.Http.Headers;

namespace ProductJudge.Mobile.DAL.Services;

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

    public async Task<ApiResultResponse<LoginResponseDto>> Login(string email, string password)
    {
        try
        {
            var response = await authApi.Login(new LoginRequestDto
            {
                Email = email,
                Password = password
            });

            if (response == null)
            {
                return ApiResultResponse<LoginResponseDto>.CreateError("Invalid username or password");
            }

            // Save token to secure storage
            //todo await SecureStorage.SetAsync("token", response.Token);

            return ApiResultResponse<LoginResponseDto>.CreateSuccess(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse<LoginResponseDto>.CreateError("Invalid username or password");
        }
    }
}
