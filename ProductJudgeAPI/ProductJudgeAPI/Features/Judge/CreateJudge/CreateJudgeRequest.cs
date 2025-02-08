using MediatR;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeRequest : IRequest<CreateJudgeResponse>
{
    public string Text = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public string ProductId { get; set; } = string.Empty;
}
