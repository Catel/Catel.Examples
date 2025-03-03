namespace Catel.Examples.Commanding
{
    using System.Windows;
    using System.Windows.Input;
    using IoC;
    using MVVM;
    using InputGesture = Windows.Input.InputGesture;

    public partial class App : Application
    {
        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            Catel.Logging.LogManager.AddDebugListener();
#endif

            base.OnStartup(e);

            var dependencyResolver = this.GetDependencyResolver();

            // Registered as command
            var commandManager = dependencyResolver.Resolve<ICommandManager>();
            commandManager.CreateCommand(Commands.Refresh, new InputGesture(Key.F5));

            // Registered in command container
            commandManager.CreateCommandWithGesture(typeof(Commands), "GlobalAction");
            commandManager.CreateCommandWithGesture(typeof(Commands), "Test1");
            commandManager.CreateCommandWithGesture(typeof(Commands), "Test2");
        }
        #endregion
    }
}
