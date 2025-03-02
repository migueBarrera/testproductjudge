using MediatR;
using ProductJudge.Api.Models.Products;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductRequest : CreateProductRequestDto , IRequest<CreateProductResponse>
{
    public IFormFileCollection Images { get; set; }
}
