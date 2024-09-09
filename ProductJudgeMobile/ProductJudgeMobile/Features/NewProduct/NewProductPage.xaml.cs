namespace ProductJudgeMobile.Features.NewProduct;

public partial class NewProductPage : ContentPage
{
	public NewProductPage(NewProductViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}