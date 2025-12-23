namespace Catel.Examples.Behaviors
{
    using System.Windows;
    using Catel.Examples.Behaviors.Views;
    using IoC;
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
            var viewLocator = _host.Services.GetRequiredService<IViewLocator>();

            viewLocator.NamingConventions.Add("[UP].Views.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]Window");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]Window");

            var viewModelLocator = _host.Services.GetRequiredService<IViewLocator>();

            viewModelLocator.NamingConventions.Add("Catel.Examples.AdvancedDemo.ViewModels.[VW]ViewModel");

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
