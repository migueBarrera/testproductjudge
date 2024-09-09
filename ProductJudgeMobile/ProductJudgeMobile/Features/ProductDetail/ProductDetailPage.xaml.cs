namespace ProductJudgeMobile.Features.ProductDetail;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(ProductDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}