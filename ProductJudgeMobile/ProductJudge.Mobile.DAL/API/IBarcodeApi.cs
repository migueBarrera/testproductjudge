using ProductJudge.Api.Models.Barcode;
using Refit;

namespace ProductJudge.Mobile.DAL.API;

public interface IBarcodeApi
{
    [Get("/Barcode")]
    Task<CheckProductByBarcodeResponseDto> CheckProductByBarcode(CheckProductByBarcodeRequestDto request);
}
