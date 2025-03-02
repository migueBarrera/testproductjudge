using ProductJudge.Api.Models.Products;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductResponse : CreateProductResponseDto
{
    public IEnumerable<string> Images = new List<string>();
}
