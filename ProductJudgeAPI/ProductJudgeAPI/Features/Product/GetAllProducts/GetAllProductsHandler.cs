using MediatR;

namespace ProductJudgeAPI.Features.Product.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
{
    private readonly ProductService applicationDbContext;

    public GetAllProductsHandler(ProductService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext.GetAsync();

        return items?.Select(x => new GetAllProductsResponse()
        {
            Id = x.Id!,
            Name = x.Name,
            Image = x.Image,
            Description = x.Description,
        }) ?? new List<GetAllProductsResponse>();
    }
}
