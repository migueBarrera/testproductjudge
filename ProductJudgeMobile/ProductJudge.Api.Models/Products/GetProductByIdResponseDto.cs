namespace ProductJudge.Api.Models.Products;

public class GetProductByIdResponseDto

{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IEnumerable<string> Images = new List<string>();

    public IEnumerable<CreateJudgeResponseDto> Judges { get; set; } = new List<CreateJudgeResponseDto>();
}
