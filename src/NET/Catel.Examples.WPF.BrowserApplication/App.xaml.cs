namespace Catel.Examples.WPF.BrowserApplication
{
    using System.Windows;
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StyleHelper.CreateStyleForwardersForDefaultStyles();

            base.OnStartup(e);
        }
    }
}
