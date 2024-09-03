using ProductJudge.Mobile.DAL.Refit;
using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.Login;
using ProductJudgeMobile.Features.MainPage;
using SecretAligner.Telemedicine.Mobile.Infrastructure;

namespace ProductJudgeMobile;

internal static class AppBuilderExtensions
{
    internal static MauiAppBuilder RegisterPagesAndViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ListProductsViewModel>();
        builder.Services.AddTransient<ListProductsPage>();

        return builder;
    }

    internal static MauiAppBuilder RegisterHttpClients(this MauiAppBuilder builder)
    {
        builder.Services
            .AddHttpClient(HttpClients.FAKE_API, httpClient =>
            {
                httpClient.BaseAddress = new Uri(HttpClients.URLS.URL_LOCAL_FAKE_API_BASE);
                httpClient.Timeout = TimeSpan.FromSeconds(10);
            })
#if DEBUG
            .ConfigurePrimaryHttpMessageHandler((c) => new HttpLoggingHandler());
#else
    ;
#endif
        return builder;
    }
}
