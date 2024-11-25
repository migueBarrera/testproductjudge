using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, IEnumerable<GetProductByIdResponse>>
{
    private readonly AppDbContext applicationDbContext;

    public GetProductByIdHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext
            .Products
            .Where(x => x.CategoryId == request.CategoryId)
            .ToListAsync(cancellationToken);

        return items.Select(x => new GetProductByIdResponse()
        {
            Id = x.Id,
            Name = x.Name,
            CategoryId = x.CategoryId,
            Description = x.Description,
        });
    }
}
