using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.ListProducts;
using System.Collections.ObjectModel;

namespace ProductJudgeMobile.Features.ProductDetail;

[QueryProperty("Product", nameof(ProductCapsule))]
public partial class ProductDetailViewModel : ObservableObject, IQueryAttributable
{
    private ProductDetailService productDetailService;

    [ObservableProperty]
    public partial ItemProduct? ProductCapsule { get; set; }

    [ObservableProperty]
    public partial string ProductImage { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductDescription { get; set; } = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Review> productReviews = new ObservableCollection<Review>();

    public ProductDetailViewModel(ProductDetailService productDetailService)
    {
        this.productDetailService = productDetailService;
    }

    // Comando para añadir una nueva opinión
    [RelayCommand]
    private void AddReview()
    {
        // Ejemplo: Añadir una opinión nueva a la lista (aquí podrías abrir una nueva vista para que el usuario ingrese una opinión)
        ProductReviews.Add(new Review { ReviewerName = "Nuevo Usuario", ReviewText = "¡Este producto es increíble!", ReviewDate = "10/09/2024" });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ProductCapsule = query["Product"] as ItemProduct;

        if (ProductCapsule != null)
        {
            ProductImage = ProductCapsule.Image.FirstOrDefault();
            ProductName = ProductCapsule.Name;
            ProductDescription = ProductCapsule.Description;
            //ProductReviews = new ObservableCollection<Review>(ProductCapsule.Reviews);
        }
    }
}
