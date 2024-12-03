using Microsoft.Extensions.Options;
using ProductJudgeAPI.Entities;
using ProductJudgeAPI.Helpers;

namespace ProductJudgeAPI.Features.Product;

public class ProductService : MongoServiceBase<Entities.Product>
{
    public ProductService(IOptions<StoreDatabaseSettings> bookStoreDatabaseSettings) 
        : base(bookStoreDatabaseSettings)
    {
    }

    public override string CollectionName()
    {
        return bookStoreDatabaseSettings.Value.ProductsCollectionName;
    }
}
