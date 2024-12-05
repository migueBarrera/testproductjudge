using MediatR;
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
        try
        {
            var user = new Entities.User()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
            };

            await applicationDbContext.CreateAsync(user);

            return new RegisterResponse()
            {
                Email = user.Email,
                Token = jwtSecurityTokenService.BuildToken(),
                RefreshToken = jwtSecurityTokenService.BuildRefreshToken(),
            };
        }
        catch (Exception e)
        {
            return new RegisterResponse()
            {
                Email = e.Message,
            };
        }
    }
}
