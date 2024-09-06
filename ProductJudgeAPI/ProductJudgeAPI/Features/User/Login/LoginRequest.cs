using MediatR;
using ProductJudge.Api.Models.Auth;

namespace ProductJudgeAPI.Features.User.Login;

public class LoginRequest : LoginRequestDto, IRequest<LoginResponse>
{
}
