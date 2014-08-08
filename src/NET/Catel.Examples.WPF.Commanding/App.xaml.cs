namespace Catel.Examples.WPF.Commanding
{
    using System.Windows;
    using System.Windows.Input;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Windows;
    using InputGesture = Catel.Windows.Input.InputGesture;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            Catel.Logging.LogManager.AddDebugListener();
#endif

            StyleHelper.CreateStyleForwardersForDefaultStyles();

            // TODO: Using a custom IoC container like Unity? Register it here:
            // Catel.IoC.ServiceLocator.Instance.RegisterExternalContainer(MyUnityContainer);

            base.OnStartup(e);

            var dependencyResolver = this.GetDependencyResolver();

            var commandManager = dependencyResolver.Resolve<ICommandManager>();
            commandManager.CreateCommand(Commands.Refresh, new InputGesture(Key.F5));
        }
    }
}