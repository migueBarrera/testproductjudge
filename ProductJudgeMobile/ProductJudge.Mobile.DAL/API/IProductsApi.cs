using ProductJudge.Api.Models.Products;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IProductsApi
{
    [Post("/api/product/create")]
    [Multipart]
    Task<CreateProductResponseDto> CreateProductWithImages(
        [AliasAs("Name")] string Name,
        [AliasAs("Description")] string Description,
        [AliasAs("Images")] IEnumerable<StreamPart> images);
    
    [Post("/api/judge")]
    Task<CreateJudgeResponseDto> AddJudge(CreateJudgeRequestDto request);

    [Get("/api/product/{id}")]
    Task<GetProductByIdResponseDto> GetProductDetail([AliasAs("id")] string productId);

    [Get("/api/product")]
    Task<IEnumerable<GetAllProductResponseDto>> GetAll(GetAllProductsRequestDto request);
}
