using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Features.Category.CreateCategory;
using ProductJudgeAPI.Features.Category.GetCategories;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Category}")]
[ApiController]
[ControllerName(ApiConstants.Controllers.Category)]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCategoryResponse>>> GetByCategory(CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new GetCategoryRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost(Name = "AddCategory")]
    public async Task<ActionResult<CreateCategoryResponse>> Add(CreateCategoryRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
