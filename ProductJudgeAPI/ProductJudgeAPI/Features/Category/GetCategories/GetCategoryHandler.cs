using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Category.GetCategories;

public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, IEnumerable<GetCategoryResponse>>
{
    private readonly AppDbContext applicationDbContext;

    public GetCategoryHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetCategoryResponse>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext.Categories.ToListAsync();

        return items.Select(x => new GetCategoryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        });
    }
}
