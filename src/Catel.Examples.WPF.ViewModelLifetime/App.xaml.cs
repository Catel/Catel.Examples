namespace Catel.Examples.ViewModelLifetime
{
    using System.Windows;
    using Catel.Examples.ViewModelLifetime.Services;
    using Catel.Examples.ViewModelLifetime.Views;
    using Catel.IoC;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

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

                    // TODO: How to make sure this is the same instance?
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<ITabService>(x => x.GetRequiredService<MainWindow>());

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

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
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
