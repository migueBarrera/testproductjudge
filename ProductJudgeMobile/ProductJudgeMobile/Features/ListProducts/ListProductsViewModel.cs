using CommunityToolkit.Mvvm.ComponentModel;

namespace ProductJudgeMobile.Features.ListProducts;

public partial class ListProductsViewModel : ObservableObject
{
    private readonly ListProductsService listProductsService;

    public ListProductsViewModel(ListProductsService listProductsService)
    {
        this.listProductsService = listProductsService;
    }

    [ObservableProperty]
    private List<object> products = [];
}
