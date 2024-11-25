namespace ProductJudgeAPI.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public ICollection<Judge> Judges { get; set; } = new List<Judge>();

    public IEnumerable<Barcode> Barcodes { get; set; } = new List<Barcode>();

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

}
