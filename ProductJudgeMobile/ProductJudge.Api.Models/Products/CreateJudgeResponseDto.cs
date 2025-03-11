namespace ProductJudge.Api.Models.Products;

public class CreateJudgeResponseDto
{
    public string Id { get; set; } = string.Empty;

    public string Judge { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.MinValue;

    public string UserId { get; set; } = string.Empty;

    public string ProductId { get; set; } = string.Empty;
}
