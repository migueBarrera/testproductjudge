using MediatR;
using ProductJudge.Api.Models.Products;

namespace ProductJudgeAPI.Features.Product.GetProductById;

public class GetProductByIdRequest : GetProductByIdRequestDto, IRequest<GetProductByIdResponse>
{

}
