using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ProductJudgeMobile.Features.NewProduct;

public partial class NewProductViewModel : ObservableObject
{
    private readonly CreateProductService createProductService;

    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductDescription { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<ImageSource> Images { get; set; } = [];

    public NewProductViewModel(CreateProductService createProductService)
    {
        this.createProductService = createProductService;
    }

    [RelayCommand]
    private async Task CaptureImage()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult? photo = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions(){

            });

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
            await Application.Current!.Windows[0].Page!.DisplayAlert("Error", "Todos los campos son obligatorios ", "OK");
            return;
        }

        var apiResponse = await createProductService.CreateProductWithImages(ProductName, ProductDescription, Images);
        if (apiResponse.IsSuccess){
            await Application.Current!.Windows[0].Page!.DisplayAlert("Éxito", "El producto ha sido creado exitosamente.", "OK");
        } else {
            await Application.Current!.Windows[0].Page!.DisplayAlert("Error", "No se ha podido crear el producto", "OK");
        }

        // var apiResponse = await createProductService.CreateProduct(ProductName, ProductDescription);

        // if (apiResponse.IsSuccess)
        // {
        //     if (Images.Count > 0)
        //     {
        //         var imageResponse = await createProductService.UploadImages(Images);
        //         if (!imageResponse.IsSuccess)
        //         {
        //             await Application.Current!.Windows[0].Page!.DisplayAlert("Error", "No se han podido subir las imágenes", "OK");
        //             return;
        //         }
        //     }

        //     await Application.Current!.Windows[0].Page!.DisplayAlert("Éxito", "El producto ha sido creado exitosamente.", "OK");
        // }
        // else
        // {
        //     await Application.Current!.Windows[0].Page!.DisplayAlert("Error", "No se ha podido crear el producto", "OK");

        // }
    }
}
