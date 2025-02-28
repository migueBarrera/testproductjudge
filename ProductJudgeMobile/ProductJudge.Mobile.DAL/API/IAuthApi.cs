using ProductJudge.Api.Models.Auth;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IAuthApi
{
    [Post("/api/user/login")]
    Task<LoginResponseDto> Login(LoginRequestDto request);

    [Post("/api/user/register")]
    Task<RegisterResponseDto> Register(RegisterRequestDto request);
}
