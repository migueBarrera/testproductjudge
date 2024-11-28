using MediatR;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly ProductService applicationDbContext;

    public CreateProductHandler(ProductService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Entities.Product()
        {
            Name = request.Name,
            Description = request.Description,
        };

        await applicationDbContext.CreateAsync(product);

        return new CreateProductResponse()
        {
            Id = product.Id,
            Name = product.Name,
        };
    }
}
