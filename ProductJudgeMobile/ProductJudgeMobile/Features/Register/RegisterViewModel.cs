using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductJudge.Mobile.DAL.Services;

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
            await SecureStorage.SetAsync("token", response.Value!.Token);
            await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
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
