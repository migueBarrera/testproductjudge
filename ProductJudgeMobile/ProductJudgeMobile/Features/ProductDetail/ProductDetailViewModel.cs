using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Features.ListProducts;
using System.Collections.ObjectModel;
using ProductJudgeMobile.Infrastructure;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;
using ProductJudge.Api.Models.Products;

namespace ProductJudgeMobile.Features.ProductDetail;

[QueryProperty("Product", nameof(ProductCapsule))]
public partial class ProductDetailViewModel : CoreViewModel, IQueryAttributable
{
    private readonly IPopupService popupService;
    private ProductDetailService productDetailService;

    [ObservableProperty]
    public partial ItemProduct? ProductCapsule { get; set; }

    [ObservableProperty]
    public partial List<Uri> ProductImages { get; set; } = new List<Uri>();

    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductDescription { get; set; } = string.Empty;

    [ObservableProperty]
    private ObservableCollection<CreateJudgeResponseDto> productReviews = new ObservableCollection<CreateJudgeResponseDto>();

    public ProductDetailViewModel(ProductDetailService productDetailService, IPopupService popupService)
    {
        this.productDetailService = productDetailService;
        this.popupService = popupService;
    }

    // Comando para añadir una nueva opinión
    [RelayCommand]
    private void AddReview()
    {
        popupService.ShowPopup<NewRewardPopupViewModel>();
        // Ejemplo: Añadir una opinión nueva a la lista (aquí podrías abrir una nueva vista para que el usuario ingrese una opinión)
        //ProductReviews.Add(new Review { ReviewerName = "Nuevo Usuario", ReviewText = "¡Este producto es increíble!", ReviewDate = "10/09/2024" });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ProductCapsule = query["Product"] as ItemProduct;

        if (ProductCapsule != null)
        {
            ProductImages = ProductCapsule.Image.Select(image => new Uri(image)).ToList();
            ProductName = ProductCapsule.Name;
            ProductDescription = ProductCapsule.Description;
            _ = NewMethod();
        }
    }

    private async Task NewMethod()
    {
        var response = await productDetailService.GetProduct(ProductCapsule!.Id);
        if (response.IsSuccess)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ProductReviews = new ObservableCollection<CreateJudgeResponseDto>(response.Value!.Judges);
            });
        }
    }
}
