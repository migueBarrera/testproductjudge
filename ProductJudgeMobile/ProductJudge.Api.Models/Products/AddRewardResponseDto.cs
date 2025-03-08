namespace ProductJudge.Api.Models.Products;

public class AddRewardResponseDto
{
    public string Id { get; set; } = string.Empty;

    public string Reward { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}
