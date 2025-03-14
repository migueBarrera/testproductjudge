using Microsoft.Extensions.Logging;
using ProductJudge.Api.Models.Auth;
using ProductJudge.Mobile.DAL.API;
using ProductJudge.Mobile.DAL.Helpers;

namespace ProductJudge.Mobile.DAL.Services;

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

    public async Task<ApiResultResponse<RegisterResponseDto>> Register(string username,string email, string password)
    {
        try
        {
            var response = await authApi.Register(new RegisterRequestDto
            {
                Email = email,
                Password = password,
                Name = username
            });

            if (response == null)
            {
                return ApiResultResponse<RegisterResponseDto>.CreateError("Invalid username or password");
            }

            return ApiResultResponse<RegisterResponseDto>.CreateSuccess(response);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return ApiResultResponse<RegisterResponseDto>.CreateError("Invalid username or password");
        }
    }
}
