using MediatR;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
