using MediatR;

namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByIdRequest : IRequest<IEnumerable<GetProductByIdResponse>>
{
    public int CategoryId { get; set; }
}
