using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductJudgeAPI.Context;
using ProductJudgeAPI.Extensions;

namespace ProductJudgeAPI.Features.User.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly UserService applicationDbContext;
    private readonly JwtSecurityTokenService jwtSecurityTokenService;

    public LoginHandler(UserService applicationDbContext, JwtSecurityTokenService jwtSecurityTokenService)
    {
        this.applicationDbContext = applicationDbContext;
        this.jwtSecurityTokenService = jwtSecurityTokenService;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Entities.Product>.Filter.Eq(u => u.Email, request.Email);
        var users = await applicationDbContext
            .GetAsync(filter);

        var user = users
            .FirstOrDefault(u => u.Password == request.Password);

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
