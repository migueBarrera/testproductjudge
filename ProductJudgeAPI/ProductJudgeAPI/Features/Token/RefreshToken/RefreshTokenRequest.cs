using MediatR;
using ProductJudgeAPI.Features.User.Register;

namespace ProductJudgeAPI.Features.Token.RefreshToken;

public class RefreshTokenRequest : IRequest<RefreshTokenResponse>
{
    public string RefreshToken { get; set; } = string.Empty;
}
