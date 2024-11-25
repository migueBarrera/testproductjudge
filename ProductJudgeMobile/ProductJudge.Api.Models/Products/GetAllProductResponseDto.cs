namespace ProductJudge.Api.Models.Products;

public class GetAllProductResponseDto
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
}
