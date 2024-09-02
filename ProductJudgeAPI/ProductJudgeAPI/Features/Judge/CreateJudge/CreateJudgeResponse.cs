namespace ProductJudgeAPI.Features.Judge.CreateJudge;

public class CreateJudgeResponse
{
    public string Text = string.Empty;

    public int UserId { get; set; }

    public int ProductId { get; set; }
}
