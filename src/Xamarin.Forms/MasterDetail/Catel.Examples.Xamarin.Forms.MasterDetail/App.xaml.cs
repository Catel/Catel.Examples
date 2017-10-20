using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Catel.Examples.Xamarin.Forms.MasterDetail
{
    using Catel.Examples.Xamarin.Forms.MasterDetail.Views;
    using global::Xamarin.Forms;

    public partial class App
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        private static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    }
                },
            };
        }
    }
}