using MediatR;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByCategoryIdRequest : IRequest<IEnumerable<GetProductByCategoryIdResponse>>
{
    public int CategoryId { get; set; }
}
