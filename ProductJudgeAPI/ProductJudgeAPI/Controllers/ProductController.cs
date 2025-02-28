using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Features.Product.CreateProduct;
using ProductJudgeAPI.Features.Product.GetAllProducts;
using ProductJudgeAPI.Features.Product.GetProductByCategoryId;
using ProductJudgeAPI.Features.Product.UploadImages;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Product}")]
[ControllerName(ApiConstants.Controllers.Product)]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<GetProductByIdResponse>>> GetByCategoryId(int id,CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new GetProductByIdRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllProductsResponse>>> GetAll(CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new GetAllProductsRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost("create", Name = "create")]
    public async Task<ActionResult<CreateProductResponse>> Add(CreateProductRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("uploadImages", Name = "UploadImages")]
    public async Task<ActionResult<CreateProductResponse>> UploadImages(
        [FromForm] IFormFileCollection images,
        CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(new UploadImagesRequest(){ Images = images }, cancellationToken);
        return Ok(response);
    }
}
