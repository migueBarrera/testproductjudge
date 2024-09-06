using ProductJudge.Api.Models.Products;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IProductsApi
{
    [Get("/DoctorProfile")]
    Task<CreateProductResponseDto> CreateProduct(CreateProductRequestDto request);

    [Post("/DoctorProfile")]
    Task<CreateProductResponseDto> GetProductDetail(CreateProductRequestDto request);
    
    [Post("/products")]
    Task<GetAllProductResponseDto> GetAll(GetAllProductsRequestDto request);
}
