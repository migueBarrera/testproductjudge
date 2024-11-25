using ProductJudgeMobile.Infrastructure;

namespace ProductJudgeMobile.Features.ListProducts;

public partial class ListProductsPage : CorePage
{
	public ListProductsPage(ListProductsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}