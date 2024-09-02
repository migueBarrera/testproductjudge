using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.User.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly AppDbContext applicationDbContext;

    public LoginHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext
            .Users
            .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken);

        return new LoginResponse()
        {

        };
    }
}
