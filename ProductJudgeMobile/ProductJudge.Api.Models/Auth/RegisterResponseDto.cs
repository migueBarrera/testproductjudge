namespace ProductJudge.Api.Models.Auth;

public class RegisterResponseDto
{
    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}
