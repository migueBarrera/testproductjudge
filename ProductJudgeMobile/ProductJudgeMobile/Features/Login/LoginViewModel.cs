using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductJudgeMobile.Features.Login;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [RelayCommand]
    private async Task Enter()
    {
        await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
        //if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
        //{
        //    // Lógica de autenticación o navegación
        //}
        //else
        //{
        //    // Mostrar mensaje de error o realizar otra acción
        //}
    }
}
