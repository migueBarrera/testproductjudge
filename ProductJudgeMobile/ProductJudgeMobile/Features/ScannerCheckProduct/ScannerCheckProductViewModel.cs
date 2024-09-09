using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui;

namespace ProductJudgeMobile.Features.ScannerCheckProduct
{
    public partial class ScannerCheckProductViewModel : ObservableObject
    {
        private ILogger<ScannerCheckProductViewModel> _logger;
        private string _lastBarcode = string.Empty;
        private readonly BarcodeService barcodeService;

        public ScannerCheckProductViewModel(ILogger<ScannerCheckProductViewModel> logger, BarcodeService barcodeService)
        {
            _logger = logger;
            this.barcodeService = barcodeService;
        }

        [RelayCommand]
        private async Task ScannerBarcode(BarcodeDetectionEventArgs barcodeDetectionEventArgs)
        {
            if (!barcodeDetectionEventArgs.Results.Any())
            {
                return;
            }

            var barcode = barcodeDetectionEventArgs.Results.First().Value;

            if (barcode == _lastBarcode)
            {
                _logger.LogWarning("Duplicate barcode detected");
                return;
            }

            _lastBarcode = barcode;

            var apiResponse = await barcodeService.CheckProductByBarcode(barcode);
            if (apiResponse.IsError)
            {
                await Shell.Current.DisplayAlert("Api error", apiResponse.ErrorMessage, "Ok");
            }
            else
            {
                if (apiResponse.Value!.ExistProduct)
                {
                    await Shell.Current.DisplayAlert("Product found", $"Product found id: {apiResponse.Value!.ProductId}", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Product not found", "Product not found", "OK");
                }
            }
            

        }
    }
}
