using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Features.Barcode.CheckProductByBarcode;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.Barcode}")]
[ControllerName(ApiConstants.Controllers.Barcode)]
[ApiController]
public class BarcodeController : Controller
{
    private readonly IMediator mediator;

    public BarcodeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<CheckProductByBarcodeResponse>> CheckProductByBarcode(CheckProductByBarcodeRequest request, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
