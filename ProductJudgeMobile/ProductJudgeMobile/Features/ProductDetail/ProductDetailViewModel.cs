using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Features.ListProducts;
using System.Collections.ObjectModel;
using ProductJudgeMobile.Infrastructure;
using CommunityToolkit.Maui.Core;

namespace ProductJudgeMobile.Features.ProductDetail;

[QueryProperty("Product", nameof(ProductCapsule))]
public partial class ProductDetailViewModel : CoreViewModel, IQueryAttributable
{
    private readonly IPopupService popupService;
    private ProductDetailService productDetailService;

    [ObservableProperty]
    public partial ItemProduct? ProductCapsule { get; set; }

    [ObservableProperty]
    public partial List<string> ProductImages { get; set; } = new List<string>();

    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductDescription { get; set; } = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Review> productReviews = new ObservableCollection<Review>();

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
            ProductImages = ProductCapsule.Image.ToList();
            ProductName = ProductCapsule.Name;
            ProductDescription = ProductCapsule.Description;
            //ProductReviews = new ObservableCollection<Review>(ProductCapsule.Reviews);
        }
    }
}
