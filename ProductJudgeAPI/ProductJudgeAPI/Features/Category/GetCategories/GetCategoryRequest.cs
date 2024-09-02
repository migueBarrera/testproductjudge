using MediatR;

namespace ProductJudgeAPI.Features.Category.GetCategories;

public class GetCategoryRequest : IRequest<IEnumerable<GetCategoryResponse>>
{
}
