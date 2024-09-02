using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductJudgeAPI.Features.Product.CreateProduct;
using ProductJudgeAPI.Features.Product.GetProductByCategoryId;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Product}")]
[ControllerName(ApiConstants.Controllers.Product)]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetProductsByCategoryId")]
    public async Task<ActionResult<IEnumerable<GetProductByCategoryIdResponse>>> GetByCategoryId(CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new GetProductByCategoryIdRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost(Name = "AddProduct")]
    public async Task<ActionResult<CreateProductResponse>> Add(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
