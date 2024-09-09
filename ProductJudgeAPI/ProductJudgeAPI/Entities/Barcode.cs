namespace ProductJudgeAPI.Entities;

public class Barcode
{
    public int Id { get; set; }

    public string Value { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public Product? Product { get; set; }

}
