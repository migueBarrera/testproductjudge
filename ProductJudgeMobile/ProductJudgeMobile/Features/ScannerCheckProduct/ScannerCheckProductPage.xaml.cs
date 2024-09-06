using ZXing.Net.Maui;

namespace ProductJudgeMobile.Features.ScannerCheckProduct;

public partial class ScannerCheckProductPage : ContentPage
{
    public ScannerCheckProductPage(ScannerCheckProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = true
        };
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
    }
}