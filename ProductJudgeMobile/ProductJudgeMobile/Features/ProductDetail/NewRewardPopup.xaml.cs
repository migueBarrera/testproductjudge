using CommunityToolkit.Maui.Views;

namespace ProductJudgeMobile.Features.ProductDetail;

public partial class NewRewardPopup : Popup
{
	public NewRewardPopup(NewRewardPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}