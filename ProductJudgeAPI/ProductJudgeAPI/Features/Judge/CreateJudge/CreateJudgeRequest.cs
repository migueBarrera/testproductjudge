using MediatR;

namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeRequest : IRequest<CreateJudgeResponse>
{
    public string Text = string.Empty;

    public int UserId { get; set; }

    public int ProductId { get; set; }
}
