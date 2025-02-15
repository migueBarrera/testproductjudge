using CommunityToolkit.Mvvm.ComponentModel;

namespace ProductJudgeMobile.Infrastructure;

public partial class CoreViewModel :
    ObservableObject,
    INavigationAwareViewModel,
    IBusyViewModel
{
    [ObservableProperty]
    public partial bool IsBusy { get;set; }

    public virtual Task OnAppearingAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnDisappearingAsync()
    {
        return Task.CompletedTask;
    }
}
