using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.NewProduct;
using ProductJudgeMobile.Features.ScannerCheckProduct;

namespace ProductJudgeMobile.Features.MainPage;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private async Task AddProduct()
    {
        bool hasBarcode = await Shell.Current.DisplayAlert("Nuevo producto", "¿Tiene código de barras?", "Si", "No");
        if (hasBarcode)
        {
            await Shell.Current.GoToAsync($"/{nameof(ScannerCheckProductPage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"/{nameof(NewProductPage)}");
        }
    }

    [RelayCommand]
    private Task CheckProduct()
    {
        return Shell.Current.GoToAsync($"/{nameof(ScannerCheckProductPage)}");
    }

    [RelayCommand]
    private Task ListProducts()
    {
        return Shell.Current.GoToAsync($"/{nameof(ListProductsPage)}");
    }
}
