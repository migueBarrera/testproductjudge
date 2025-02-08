using MediatR;
using ProductJudge.Api.Models.Products;

namespace ProductJudgeAPI.Features.Product.GetAllProducts;

public class GetAllProductsRequest : GetAllProductsRequestDto, IRequest<IEnumerable<GetAllProductsResponse>>
{
}
