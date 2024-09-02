namespace ProductJudgeAPI.Features.Product.GetProductByCategoryId;

public class GetProductByCategoryIdResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
}
