namespace Catel.Examples.WPF.TaskCommand
{
    using System.Windows;
    using Catel.Logging;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LogManager.AddDebugListener();
        }
    }
}
