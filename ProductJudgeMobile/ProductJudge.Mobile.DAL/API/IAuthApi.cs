using ProductJudge.Api.Models.Auth;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IAuthApi
{
    [Post("/api/user/login")]
    [Headers("Content-Type: application/json")]
    Task<LoginResponseDto> Login(LoginRequestDto request);

    [Post("/api/user/register")]
    Task<RegisterResponseDto> Register(RegisterRequestDto request);
}
