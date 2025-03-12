using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Features.Judge.CreateJudge;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Judge}")]
[ControllerName(ApiConstants.Controllers.Judge)]
[ApiController]
public class JudgeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CategoryController> _logger;

    public JudgeController(ILogger<CategoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }


    [HttpPost(Name = "AddJudge")]
    //[Authorize]
    [ProducesResponseType(typeof(CreateJudgeResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(CreateJudgeRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
