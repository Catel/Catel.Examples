// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2018 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Catel.Examples.Xamarin.Forms.MasterDetail
{
    using global::Xamarin.Forms;
    using Views;

    public partial class App
    {
        #region Constructors
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }
        #endregion

        #region Methods
        private static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        IconImageSource = "tab_feed.png"
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        IconImageSource = "tab_about.png"
                    }
                },
            };
        }
        #endregion
    }
}
