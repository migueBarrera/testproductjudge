namespace ProductJudge.Api.Models.Products;

public class CreateProductResponseDto
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IEnumerable<string> Images = new List<string>();
}
