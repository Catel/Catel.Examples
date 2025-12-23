namespace Catel.Examples.Authentication
{
    using System.Windows;
    using Catel.Examples.Authentication.Views;
    using Catel.IoC;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using MVVM;

    public partial class App
    {
#pragma warning disable IDISP006 // Implement IDisposable
        private readonly IHost _host;
#pragma warning restore IDISP006 // Implement IDisposable

        public App()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCatelCoreServices();
                    services.AddCatelMvvmServices();

                    services.AddSingleton<IAuthenticationProvider, AuthenticationProvider>();

                    services.AddLogging(x =>
                    {
                        x.AddConsole();
                        x.AddDebug();
                    });
                });

            _host = hostBuilder.Build();

            IoCContainer.ServiceProvider = _host.Services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ActivatorUtilities.CreateInstance<MainWindow>(_host.Services);
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
