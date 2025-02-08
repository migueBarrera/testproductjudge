using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ProductJudgeMobile.Features.NewProduct;

public partial class NewProductViewModel : ObservableObject
{
    private readonly CreateProductService createProductService;

    [ObservableProperty]
    private string productName = string.Empty;

    [ObservableProperty]
    private string productDescription = string.Empty;

    [ObservableProperty]
    private ObservableCollection<ImageSource> images = [];

    public NewProductViewModel(CreateProductService createProductService)
    {
        this.createProductService = createProductService;
    }

    [RelayCommand]
    private async Task CaptureImage()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                using Stream sourceStream = await photo.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await sourceStream.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var imageStream = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                Images.Add(imageStream);
            }
        }
    }

    [RelayCommand]
    private async Task CreateProduct()
    {
        if (string.IsNullOrWhiteSpace(ProductName) ||
            string.IsNullOrWhiteSpace(ProductDescription))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios ", "OK");
            return;
        }

        var apiResponse = await createProductService.CreateProduct(ProductName, ProductDescription);

        if (apiResponse.IsSuccess)
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", "El producto ha sido creado exitosamente.", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido crear el producto", "OK");

        }
    }
}
