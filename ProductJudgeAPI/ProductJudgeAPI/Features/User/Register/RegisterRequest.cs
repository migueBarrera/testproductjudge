using MediatR;
using ProductJudge.Api.Models.Auth;

namespace ProductJudgeAPI.Features.User.Register;

public class RegisterRequest : RegisterRequestDto , IRequest<RegisterResponse>
{
}
