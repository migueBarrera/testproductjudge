using MediatR;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.User.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly AppDbContext applicationDbContext;

    public RegisterHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
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

        };
    }
}
