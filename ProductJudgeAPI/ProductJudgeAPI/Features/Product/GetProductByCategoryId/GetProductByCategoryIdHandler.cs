using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByCategoryIdHandler : IRequestHandler<GetProductByCategoryIdRequest, IEnumerable<GetProductByCategoryIdResponse>>
{
    private readonly AppDbContext applicationDbContext;

    public GetProductByCategoryIdHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetProductByCategoryIdResponse>> Handle(GetProductByCategoryIdRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext
            .Products
            .Where(x => x.CategoryId == request.CategoryId)
            .ToListAsync(cancellationToken);

        return items.Select(x => new GetProductByCategoryIdResponse()
        {
            Id = x.Id,
            Name = x.Name,
            CategoryId = x.CategoryId,
            Description = x.Description,
        });
    }
}
