namespace Catel.Examples.WPF.MultiLingual
{
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using Windows;
    using Catel.IoC;
    using Catel.Services;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(MultiLingual.Properties.Settings.Default.DefaultLanguage);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            StyleHelper.CreateStyleForwardersForDefaultStyles();

            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<ILanguageService, Services.LanguageService>();

            base.OnStartup(e);
        }
    }
}