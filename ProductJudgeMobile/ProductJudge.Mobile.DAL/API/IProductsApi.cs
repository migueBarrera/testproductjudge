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
    
    // [Post("/api/product/create")]
    // Task<CreateProductResponseDto> CreateProduct(CreateProductRequestDto request);

    // [Post("/api/product/uploadImages")]
    // [Multipart]
    // Task<CreateProductResponseDto> UploadProductImages([AliasAs("images")] IEnumerable<StreamPart> images);

    [Get("/api/product/{id}")]
    Task<GetProductByResponseDto> GetProductDetail([AliasAs("id")] string productId);

    [Get("/api/product")]
    Task<IEnumerable<GetAllProductResponseDto>> GetAll(GetAllProductsRequestDto request);
}
