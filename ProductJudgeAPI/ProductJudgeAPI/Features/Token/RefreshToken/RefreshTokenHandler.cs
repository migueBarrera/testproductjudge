using MediatR;

namespace ProductJudgeAPI.Features.Token.RefreshToken;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
{
    public Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
