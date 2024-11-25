using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Product.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<GetAllProductsResponse>>
{
    private readonly AppDbContext applicationDbContext;

    public GetAllProductsHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext.Products.ToListAsync(cancellationToken);

        return items.Select(x => new GetAllProductsResponse()
        {
            Id = x.Id,
            Name = x.Name,
            Image = x.Image,
            Description = x.Description,
            CategoryId = x.CategoryId,
        });
    }
}
