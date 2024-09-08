using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using ZXing.Net.Maui.Controls;

namespace ProductJudgeMobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .RegisterHttpClients()
            .RegisterPagesAndViewModels()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureLifecycleEvents(events =>
            {

#if IOS
                //events.AddiOS(iOS => iOS.FinishedLaunching((App, launchOptions) => {
                //        Firebase.Core.App.Configure();
                //    Firebase.Crashlytics.Crashlytics.SharedInstance.Init();
                //    Firebase.Crashlytics.Crashlytics.SharedInstance.SetCrashlyticsCollectionEnabled(true);
                //    Firebase.Crashlytics.Crashlytics.SharedInstance.SendUnsentReports();
                //        return false;   
                //}));
#else
                events.AddAndroid(android => android.OnCreate((activity, bundle) =>
                {
                    Firebase.FirebaseApp.InitializeApp(activity);
                }));
#endif


            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
