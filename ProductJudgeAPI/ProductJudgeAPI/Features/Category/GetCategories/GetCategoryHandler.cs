using MediatR;

namespace ProductJudgeAPI.Features.Category.GetCategories;

public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, IEnumerable<GetCategoryResponse>>
{
    private readonly CategoryService applicationDbContext;

    public GetCategoryHandler(CategoryService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<GetCategoryResponse>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var items = await applicationDbContext.GetAsync();

        return items.Select(x => new GetCategoryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        });
    }
}
