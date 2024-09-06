using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;
using ProductJudgeAPI.Extensions;

namespace ProductJudgeAPI.Features.User.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly AppDbContext applicationDbContext;
    private readonly JwtSecurityTokenService jwtSecurityTokenService;

    public LoginHandler(AppDbContext applicationDbContext, JwtSecurityTokenService jwtSecurityTokenService)
    {
        this.applicationDbContext = applicationDbContext;
        this.jwtSecurityTokenService = jwtSecurityTokenService;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext
            .Users
            .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return new LoginResponse()
        {
            Email = user.Email,
            Token = jwtSecurityTokenService.BuildToken(),
            RefreshToken = jwtSecurityTokenService.BuildRefreshToken(),
        };
    }
}
