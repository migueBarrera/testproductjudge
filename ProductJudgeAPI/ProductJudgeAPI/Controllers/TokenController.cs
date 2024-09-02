using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI;
using ProductJudgeAPI.Features.Token.RefreshToken;
using System.Threading;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Token}")]
[ControllerName(ApiConstants.Controllers.Token)]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IMediator mediator;

    public TokenController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<RefreshTokenResponse>> RefresTokenClient(RefreshTokenRequest request, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
