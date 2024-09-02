using MediatR;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly AppDbContext applicationDbContext;

    public CreateProductHandler(AppDbContext applicationDbContext)
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

        applicationDbContext.Products.Add(product);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse()
        {
            Id = product.Id,
            Name = product.Name,
        };
    }
}
