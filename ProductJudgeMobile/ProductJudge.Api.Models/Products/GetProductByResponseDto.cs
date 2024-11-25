namespace ProductJudge.Api.Models.Products;

public class GetProductByResponseDto

{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
}
