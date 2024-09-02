using MediatR;

namespace ProductJudgeAPI.Features.Category.CreateCategory;

public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
{
    public string Name { get; set; } = string.Empty;
}
