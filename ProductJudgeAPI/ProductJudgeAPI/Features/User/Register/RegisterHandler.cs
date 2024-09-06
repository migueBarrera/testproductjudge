using MediatR;
using ProductJudgeAPI.Context;
using ProductJudgeAPI.Extensions;

namespace ProductJudgeAPI.Features.User.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly AppDbContext applicationDbContext;
    private readonly JwtSecurityTokenService jwtSecurityTokenService;

    public RegisterHandler(AppDbContext applicationDbContext, JwtSecurityTokenService jwtSecurityTokenService)
    {
        this.applicationDbContext = applicationDbContext;
        this.jwtSecurityTokenService = jwtSecurityTokenService;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = new Entities.User()
        {
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
        };

        applicationDbContext.Users.Add(user);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return new RegisterResponse()
        {
            Email = user.Email,
            Token = jwtSecurityTokenService.BuildToken(),
            RefreshToken = jwtSecurityTokenService.BuildRefreshToken(),
        };
    }
}
