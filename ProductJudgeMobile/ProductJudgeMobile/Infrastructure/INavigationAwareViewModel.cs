namespace ProductJudgeMobile.Infrastructure;

public interface INavigationAwareViewModel
{
    Task OnAppearingAsync();
    Task OnDisappearingAsync();
}
