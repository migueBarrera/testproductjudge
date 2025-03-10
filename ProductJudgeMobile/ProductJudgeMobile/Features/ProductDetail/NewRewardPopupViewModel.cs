using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Infrastructure;

namespace ProductJudgeMobile.Features.ProductDetail;

public partial class NewRewardPopupViewModel : CoreViewModel
{
    private readonly RewardProductService rewardProductService;
    private readonly IPopupService popupService;

    [ObservableProperty]
    private partial string RewardName { get; set; } = string.Empty;

    public NewRewardPopupViewModel(RewardProductService rewardProductService, IPopupService popupService)
    {
        this.rewardProductService = rewardProductService;
        this.popupService = popupService;
    }

    [RelayCommand]
    private async Task AddReward()
    {
        if (string.IsNullOrEmpty(RewardName))
        {
            //await DialogService.ShowAlertAsync("Please enter reward name", "Error", "OK");
            return;
        }

        await rewardProductService.AddOpinion(RewardName, "todo");
        await popupService.ClosePopupAsync();
    }
}
