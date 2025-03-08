using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Features.Register;

namespace ProductJudgeMobile.Features.Login;

public partial class LoginViewModel : ObservableObject
{
    private readonly LoginService loginService;

    public LoginViewModel(LoginService loginService)
    {
        this.loginService = loginService;

        Email = "test1@test.com";
        Password = "test1";
    }

    [ObservableProperty]
    public partial string Email { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Password { get; set; } = string.Empty;


    [RelayCommand]
    private async Task Enter()
    {
        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            await ShowErrorDialog("Fill data");
        }

        var response = await loginService.Login(Email, Password);
        if (response.IsSuccess)
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
        else
        {
            await ShowErrorDialog("Invalid username or password");
        }
    }

    private Task ShowErrorDialog(string message)
    {
        return Application.Current!.Windows[0].Page!.DisplayAlert("Error", message, "Ok");
    }

    [RelayCommand]
    private async Task Register()
    {
        await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
    }
}
