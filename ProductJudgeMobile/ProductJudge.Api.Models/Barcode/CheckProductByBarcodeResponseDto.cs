namespace ProductJudge.Api.Models.Barcode;

public class CheckProductByBarcodeResponseDto
{
    public bool ExistProduct { get; set; }

    public string ProductId { get; set; } = string.Empty;
}
