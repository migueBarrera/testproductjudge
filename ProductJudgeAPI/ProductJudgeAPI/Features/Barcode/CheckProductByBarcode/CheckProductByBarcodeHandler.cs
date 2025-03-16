using MediatR;
using MongoDB.Driver;
using ProductJudgeAPI.Features.Product;

namespace ProductJudgeAPI.Features.Barcode.CheckProductByBarcode;

public class CheckProductByBarcodeHandler : IRequestHandler<CheckProductByBarcodeRequest, CheckProductByBarcodeResponse>
{
    private readonly BarcodeService barcodeService;
    private readonly ProductService productService;

    public CheckProductByBarcodeHandler(ProductService productService, BarcodeService barcodeService)
    {
        this.productService = productService;
        this.barcodeService = barcodeService;
    }

    public async Task<CheckProductByBarcodeResponse> Handle(CheckProductByBarcodeRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Entities.Barcode>.Filter.Eq(b => b.Value, request.Barcode);
        var existBarcode = await barcodeService
            .GetAsync(filter);

        if (existBarcode is null || existBarcode.Count == 0)
        {
            return new CheckProductByBarcodeResponse()
            {
                ExistProduct = false
            };
        }

        var product = await productService
            .GetAsync(existBarcode.First().ProductId);

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
            ProductId = product.Id!,
        };
    }
}
