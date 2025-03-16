using MediatR;

namespace ProductJudgeAPI.Features.Category.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly CategoryService applicationDbContext;

    public CreateCategoryHandler(CategoryService applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new Entities.Category()
        {
            Name = request.Name,
        };

        await applicationDbContext.CreateAsync(category);

        return new CreateCategoryResponse()
        {
            Id = category.Id!,
            Name = category.Name,
        };
    }
}
