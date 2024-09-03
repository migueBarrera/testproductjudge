namespace ProductJudgeMobile.Features.ListProducts;

public partial class ListProductsPage : ContentPage
{
	public ListProductsPage(ListProductsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}