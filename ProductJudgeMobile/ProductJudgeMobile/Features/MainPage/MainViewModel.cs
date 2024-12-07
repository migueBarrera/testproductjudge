using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.NewProduct;
using ProductJudgeMobile.Features.ScannerCheckProduct;

namespace ProductJudgeMobile.Features.MainPage;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private Task AddProduct()
    {
        return Shell.Current.GoToAsync($"/{nameof(NewProductPage)}");
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
