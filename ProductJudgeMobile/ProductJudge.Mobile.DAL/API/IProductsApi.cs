using ProductJudge.Api.Models.Products;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IProductsApi
{
    [Put("/api/product")]
    Task<CreateProductResponseDto> CreateProduct(CreateProductRequestDto request);

    [Get("/api/product/{id}")]
    Task<GetProductByResponseDto> GetProductDetail([AliasAs("id")] int productId);
    
    [Get("/api/product")]
    Task<IEnumerable<GetAllProductResponseDto>> GetAll(GetAllProductsRequestDto request);
}
