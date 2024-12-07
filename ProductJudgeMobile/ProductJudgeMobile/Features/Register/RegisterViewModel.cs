using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProductJudgeMobile.Features.Register;

public partial class RegisterViewModel : ObservableObject
{
    private readonly RegisterService registerService;

    public RegisterViewModel(RegisterService registerService)
    {
        this.registerService = registerService;

        UserName = "test1";
        Email = "test1@test.com";
        Password = "test1";
    }

    [ObservableProperty]
    private string userName = string.Empty;
    
    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [RelayCommand]
    private async Task Register()
    {
        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
        {
            await ShowErrorDialog("Fill data");
            return;
        }

        var response = await registerService.Register(UserName,Email, Password);
        if (response.IsSuccess)
        {
            await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
        }
        else
        {
            await ShowErrorDialog("Invalid username or password");
        }
    }

    private Task ShowErrorDialog(string message)
    {
        return Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
    }
}
