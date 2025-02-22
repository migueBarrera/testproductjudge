using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;

namespace ProductJudgeMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureLogger()
            .UseBarcodeReader()
            .RegisterHttpClients()
            .UseMauiCommunityToolkit()
            .RegisterPagesAndViewModels()
            .RemoveAndroidEntryUnderline()
            .RegisterFonts();

        return builder.Build();
    }
}
