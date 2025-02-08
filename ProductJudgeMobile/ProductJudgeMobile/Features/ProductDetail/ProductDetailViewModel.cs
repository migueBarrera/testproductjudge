using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ProductJudgeMobile.Features.ProductDetail;

public partial class ProductDetailViewModel : ObservableObject
{
    private ProductDetailService productDetailService;

    // Propiedades del producto
    [ObservableProperty]
    private string productImage;

    [ObservableProperty]
    private string productName;

    [ObservableProperty]
    private string productDescription;

    [ObservableProperty]
    private ObservableCollection<Review> productReviews;

    public ProductDetailViewModel(ProductDetailService productDetailService)
    {
        // Ejemplo de datos iniciales
        ProductImage = "https://dreamfood.es/10579-large_default/cocacola-original-330ml.jpg";
        ProductDescription = "Este es un producto excelente que deberías considerar.";
        ProductName = "Jamón iberico";

        // Opiniones de ejemplo
        ProductReviews = new ObservableCollection<Review>
        {
            new Review { ReviewerName = "Juan", ReviewText = "Muy buen producto!", ReviewDate = "01/09/2024" },
            new Review { ReviewerName = "Ana", ReviewText = "Cumple con lo prometido.", ReviewDate = "02/09/2024" }
        };
        this.productDetailService = productDetailService;
    }

    // Comando para añadir una nueva opinión
    [RelayCommand]
    private void AddReview()
    {
        // Ejemplo: Añadir una opinión nueva a la lista (aquí podrías abrir una nueva vista para que el usuario ingrese una opinión)
        ProductReviews.Add(new Review { ReviewerName = "Nuevo Usuario", ReviewText = "¡Este producto es increíble!", ReviewDate = "10/09/2024" });
    }
}
