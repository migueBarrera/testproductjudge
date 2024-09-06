using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.ListProducts;

namespace ProductJudgeMobile.Features.MainPage;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private void AddProduct()
    {
    
    }

    [RelayCommand]
    private void CheckProduct()
    {

    }

    [RelayCommand]
    private Task ListProducts()
    {
        return Shell.Current.GoToAsync($"/{nameof(ListProductsPage)}");
    }
}
