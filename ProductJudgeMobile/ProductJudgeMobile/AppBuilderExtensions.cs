﻿using Microsoft.Extensions.Logging;
using ProductJudge.Mobile.DAL.Refit;
using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.Login;
using ProductJudgeMobile.Features.MainPage;
using ProductJudgeMobile.Features.NewProduct;
using ProductJudgeMobile.Features.ProductDetail;
using ProductJudgeMobile.Features.Register;
using ProductJudgeMobile.Features.ScannerCheckProduct;
using SecretAligner.Telemedicine.Mobile.Infrastructure;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace ProductJudgeMobile;

internal static class AppBuilderExtensions
{
    internal static MauiAppBuilder RegisterPagesAndViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ListProductsViewModel>();
        builder.Services.AddTransient<ListProductsPage>();
        builder.Services.AddTransient<ScannerCheckProductPage>();
        builder.Services.AddTransient<ScannerCheckProductViewModel>();
        builder.Services.AddTransient<ProductDetailPage>();
        builder.Services.AddTransient<ProductDetailViewModel>();
        builder.Services.AddTransient<NewProductPage>();
        builder.Services.AddTransient<NewProductViewModel>();

        builder.Services.AddTransient<LoginService>();
        builder.Services.AddTransient<RegisterService>();
        builder.Services.AddTransient<ListProductsService>();
        builder.Services.AddTransient<ProductDetailService>();
        builder.Services.AddTransient<BarcodeService>();
        builder.Services.AddTransient<CreateProductService>();

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
        .ConfigurePrimaryHttpMessageHandler(serviceProvider =>
        {
            var logger = serviceProvider.GetRequiredService<ILogger<HttpLoggingHandler>>();
            return new HttpLoggingHandler(logger);
        });
#else
    ;
#endif
        return builder;
    }

    internal static MauiAppBuilder RemoveAndroidEntryUnderline(this MauiAppBuilder builder)
    {
#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
        {
            h.PlatformView.BackgroundTintList =
            Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        });
#endif
        return builder;
    }

    internal static MauiAppBuilder RegisterFonts(this MauiAppBuilder builder)
    {
        builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                fonts.AddFont("Roboto-SemiBold.ttf", "RobotoSemiBold");
            }
            );
        return builder;
    }

        internal static MauiAppBuilder ConfigureLogger(this MauiAppBuilder builder)
    {
        #if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder;
    }
}
