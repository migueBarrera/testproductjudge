using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;
using ProductJudgeAPI.Extensions;
using ProductJudgeAPI.Features.User.Login;

namespace ProductJudgeAPI.Features.Barcode.CheckProductByBarcode;

public class CheckProductByBarcodeHandler : IRequestHandler<CheckProductByBarcodeRequest, CheckProductByBarcodeResponse>
{
    private readonly AppDbContext applicationDbContext;

    public CheckProductByBarcodeHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CheckProductByBarcodeResponse> Handle(CheckProductByBarcodeRequest request, CancellationToken cancellationToken)
    {
        var existBarcode = await applicationDbContext
            .Barcodes
            .FirstOrDefaultAsync(x => x.Value == request.Barcode, cancellationToken);

        if (existBarcode is null)
        {
            return new CheckProductByBarcodeResponse()
            {
                ExistProduct = false
            };
        }

        var product = await applicationDbContext
            .Products
            .FirstOrDefaultAsync(x => x.Id == existBarcode.ProductId, cancellationToken);

        if (product is null)
        {
            return new CheckProductByBarcodeResponse()
            {
                ExistProduct = false
            };
        }

        return new CheckProductByBarcodeResponse()
        {
            ExistProduct = true,
            ProductId = product.Id,
        };
    }
}
