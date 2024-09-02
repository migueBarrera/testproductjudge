using MediatR;
using ProductJudgeAPI.Context;

namespace ProductJudgeAPI.Features.Category.CreateCategory;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly AppDbContext applicationDbContext;

    public CreateCategoryHandler(AppDbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new Entities.Category()
        {
            Name = request.Name,
        };

        applicationDbContext.Categories.Add(category);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateCategoryResponse()
        {
            Id = category.Id,
            Name = category.Name,
        };
    }
}
