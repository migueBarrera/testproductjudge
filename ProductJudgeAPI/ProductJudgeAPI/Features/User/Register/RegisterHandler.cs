using MediatR;
using MongoDB.Driver;
using ProductJudgeAPI.Extensions;

namespace ProductJudgeAPI.Features.User.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly UserService applicationDbContext;
    private readonly JwtSecurityTokenService jwtSecurityTokenService;

    public RegisterHandler(UserService applicationDbContext, JwtSecurityTokenService jwtSecurityTokenService)
    {
        this.applicationDbContext = applicationDbContext;
        this.jwtSecurityTokenService = jwtSecurityTokenService;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Entities.User>.Filter.Eq(u => u.Email, request.Email);
        var users = await applicationDbContext
            .GetAsync(filter);

        if (users.Any())
        {
            throw new Exception("User register.");
        }

        var newUser = new Entities.User()
        {
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
        };

        await applicationDbContext.CreateAsync(newUser);

        return new RegisterResponse()
        {
            Email = newUser.Email,
            Token = jwtSecurityTokenService.BuildToken(),
            RefreshToken = jwtSecurityTokenService.BuildRefreshToken(),
        };
    }
}
