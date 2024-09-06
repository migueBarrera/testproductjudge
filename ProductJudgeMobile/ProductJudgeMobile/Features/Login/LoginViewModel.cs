using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudgeMobile.Features.Register;

namespace ProductJudgeMobile.Features.Login;

public partial class LoginViewModel : ObservableObject
{
    private readonly LoginService loginService;

    public LoginViewModel(LoginService loginService)
    {
        this.loginService = loginService;

        UserName = "test";
        Password = "test";
    }

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;


    [RelayCommand]
    private async Task Enter()
    {
        if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
        {
            var response = await loginService.Login(UserName, Password);
            if (response.IsSuccess)
            {
                await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
            }
            else
            {
                await ShowErrorDialog("Invalid username or password");
            }
        }
        else
        {
            await ShowErrorDialog("Fill data");
        }
    }

    private Task ShowErrorDialog(string message)
    {
        return Application.Current.MainPage.DisplayAlert("Error", message, "Ok");
    }

    [RelayCommand]
    private async Task Register()
    {
        await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
    }
}
