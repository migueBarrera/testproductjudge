using MediatR;
using ProductJudge.Api.Models.Products;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeRequest : CreateJudgeRequestDto, IRequest<CreateJudgeResponse>
{

}
