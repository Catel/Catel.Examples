namespace Catel.Examples.Authentication
{
    using System.Windows;
    using MVVM;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<IAuthenticationProvider, AuthenticationProvider>();
        }
    }
}
