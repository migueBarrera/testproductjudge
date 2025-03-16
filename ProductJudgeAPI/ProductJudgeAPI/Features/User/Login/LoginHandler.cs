using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ProductJudgeAPI.Exceptions;
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
        var filter = Builders<Entities.User>.Filter.Eq(u => u.Email, request.Email);
        var users = await applicationDbContext
            .GetAsync(filter);

        var user = users
            .FirstOrDefault(u => u.Password == request.Password);

        Ensure.That(user != null, ExceptionMessagesConstants.InvalidCredentials);

        return new LoginResponse()
        {
            Email = user!.Email,
            Name = user!.Name,
            Token = jwtSecurityTokenService.BuildToken(),
            RefreshToken = jwtSecurityTokenService.BuildRefreshToken(),
        };
    }
}
