namespace Catel.Examples.Commanding
{
    using System.Windows;
    using System.Windows.Input;
    using Catel.Examples.Commanding.Views;
    using Catel.IoC;
    using Catel.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MVVM;
    using InputGesture = Windows.Input.InputGesture;

    public partial class App : Application
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
                });

            _host = hostBuilder.Build();

            IoCContainer.ServiceProvider = _host.Services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            Catel.Logging.LogManager.AddDebugListener();
#endif

            base.OnStartup(e);

            TypeCache.InitializeTypes(typeof(App).Assembly);

            // Registered as command
            var commandManager = _host.Services.GetRequiredService<ICommandManager>();
            commandManager.CreateCommand(Commands.Refresh, new InputGesture(Key.F5));

            // Registered in command container
            commandManager.CreateCommandWithGesture(_host.Services, typeof(Commands), Commands.GlobalAction);
            commandManager.CreateCommandWithGesture(_host.Services, typeof(Commands), Commands.Test1);
            commandManager.CreateCommandWithGesture(_host.Services, typeof(Commands), Commands.Test2);

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
