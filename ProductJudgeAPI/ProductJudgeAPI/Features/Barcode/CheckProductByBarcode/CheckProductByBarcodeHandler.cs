using MediatR;
using MongoDB.Driver;
using ProductJudgeAPI.Entities;

namespace ProductJudgeAPI.Features.Barcode.CheckProductByBarcode;

public class CheckProductByBarcodeHandler : IRequestHandler<CheckProductByBarcodeRequest, CheckProductByBarcodeResponse>
{
    private readonly BooksService applicationDbContext;

    public CheckProductByBarcodeHandler(BooksService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CheckProductByBarcodeResponse> Handle(CheckProductByBarcodeRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Eq(b => b.Author, "Gabriel García Márquez");
        var existBarcode = await applicationDbContext
            .GetAsync(filter);

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
