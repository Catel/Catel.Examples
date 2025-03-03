namespace Catel.Examples.MultiLingual
{
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using Catel.Services;
    using IoC;

    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(MultiLingual.Properties.Settings.Default.DefaultLanguage);
        }
        #endregion

        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<ILanguageService, Services.LanguageService>();

            base.OnStartup(e);
        }
        #endregion
    }
}