using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL;
using ProductJudge.Mobile.DAL.Services;
using ProductJudgeMobile.Infrastructure;
using ProductJudgeMobile.Services;

namespace ProductJudgeMobile.Features.Register;

public partial class RegisterViewModel : ObservableObject
{
    private readonly RegisterService registerService;
    private readonly SesionServices sesionServices;

    public RegisterViewModel(RegisterService registerService, SesionServices sesionServices)
    {
        this.registerService = registerService;
        this.sesionServices = sesionServices;


        UserName = TestDALConstants.TEST_USER;
        Email = TestDALConstants.TEST_EMAIL;
        Password = TestDALConstants.TEST_PASSWORD;
    }

    [ObservableProperty]
    public partial string UserName { get; set; } = string.Empty;
    
    [ObservableProperty]
    public partial string Email { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Password { get; set; } = string.Empty;

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
}
