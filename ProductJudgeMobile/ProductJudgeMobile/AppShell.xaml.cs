using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.Login;
using ProductJudgeMobile.Features.MainPage;
using ProductJudgeMobile.Features.ProductDetail;
using ProductJudgeMobile.Features.Register;

namespace ProductJudgeMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ListProductsPage), typeof(ListProductsPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
    }
}
