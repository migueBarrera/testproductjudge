using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Features.Register;
using ProductJudgeMobile.Infrastructure;
using ProductJudgeMobile.Services;

namespace ProductJudgeMobile.Features.Login;

public partial class LoginViewModel : ObservableObject
{
    private readonly LoginService loginService;
    private readonly SesionServices sesionServices;

    public LoginViewModel(LoginService loginService, SesionServices sesionServices)
    {
        this.loginService = loginService;

        Email = TestDALConstants.TEST_EMAIL;
        Password = TestDALConstants.TEST_PASSWORD;
        this.sesionServices = sesionServices;
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
            await sesionServices.StoreSessionAsync(response.Value!.Token, response.Value!.RefreshToken);
            await Shell.Current.GoToAsync($"///{PageRoutes.Home}");
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
