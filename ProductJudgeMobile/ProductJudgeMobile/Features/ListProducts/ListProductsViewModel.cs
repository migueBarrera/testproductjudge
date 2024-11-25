using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Api.Models.Products;
using ProductJudgeMobile.Features.ProductDetail;
using ProductJudgeMobile.Infrastructure;

namespace ProductJudgeMobile.Features.ListProducts;

public partial class ListProductsViewModel : CoreViewModel
{
    private readonly ListProductsService listProductsService;

    public ListProductsViewModel(ListProductsService listProductsService)
    {
        this.listProductsService = listProductsService;
    }

    [ObservableProperty]
    private IEnumerable<GetAllProductResponseDto> products = new List<GetAllProductResponseDto>();

    [ObservableProperty]
    private GetAllProductResponseDto? selected;

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await GetProducts();
    }

    private async Task GetProducts()
    {
        IEnumerable<GetAllProductResponseDto> response = await listProductsService.GetProducts();
        Products = response.ToList();
    }

    [RelayCommand]
    private async Task Clicked()
    {
        if (Selected != null)
        {
            Selected = null;
            await Shell.Current.GoToAsync(nameof(ProductDetailPage));
        }
    }
}
