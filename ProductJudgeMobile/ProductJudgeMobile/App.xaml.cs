using ProductJudgeMobile.Features.ListProducts;
using ProductJudgeMobile.Features.Login;
using ProductJudgeMobile.Features.MainPage;

namespace ProductJudgeMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ListProductsPage), typeof(ListProductsPage));
        }
    }
}
