using ProductJudge.Api.Models.Auth;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IAuthApi
{
    [Get("/api/user")]
    [Headers("Content-Type: application/json")]
    Task<LoginResponseDto> Login(LoginRequestDto request);

    [Post("/api/user")]
    Task<RegisterResponseDto> Register(RegisterRequestDto request);
}
