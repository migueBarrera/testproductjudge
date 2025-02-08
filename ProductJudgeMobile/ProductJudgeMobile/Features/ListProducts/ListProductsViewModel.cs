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
    private IEnumerable<ItemProduct> products = new List<ItemProduct>();

    [ObservableProperty]
    private ItemProduct? selected;

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await GetProducts();
    }

    private async Task GetProducts()
    {
        IEnumerable<GetAllProductResponseDto> response = await listProductsService.GetProducts();
        Products = response.Select(x => new ItemProduct(x)).ToList();
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
