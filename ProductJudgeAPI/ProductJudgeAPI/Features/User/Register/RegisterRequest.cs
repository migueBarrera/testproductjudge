using MediatR;

namespace ProductJudgeAPI.Features.User.Register;

public class RegisterRequest : IRequest<RegisterResponse>
{
    public string Email = string.Empty;

    public string Password = string.Empty;

    public string Name = string.Empty;
}
