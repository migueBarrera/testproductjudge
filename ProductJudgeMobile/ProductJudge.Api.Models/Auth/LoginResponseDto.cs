﻿namespace ProductJudge.Api.Models.Auth;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
