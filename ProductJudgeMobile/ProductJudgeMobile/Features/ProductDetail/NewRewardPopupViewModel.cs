using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Infrastructure;

namespace ProductJudgeMobile.Features.ProductDetail;

public partial class NewRewardPopupViewModel : CoreViewModel
{
    private readonly JudgeProductService judgeProductService;
    private readonly IPopupService popupService;

    [ObservableProperty]
    private partial string RewardName { get; set; } = string.Empty;

    public NewRewardPopupViewModel(JudgeProductService judgeProductService, IPopupService popupService)
    {
        this.judgeProductService = judgeProductService;
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

        await judgeProductService.AddJudge(RewardName, "todo", "todo");
        await popupService.ClosePopupAsync();
    }
}
