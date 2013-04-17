namespace Catel.Examples.WPF.Prism
{
    using IoC;
    using MVVM.Services;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">More than one instance of the <see cref="T:System.Windows.Application"/> class is created per <see cref="T:System.AppDomain"/>.</exception>
        public App()
        {
            var dispatcherService = ServiceLocator.Default.ResolveType<IDispatcherService>();

            dispatcherService.BeginInvoke(() =>
            {
                Environment.RegisterDefaultViewModelServices();

                var bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            });
        }
    }
}