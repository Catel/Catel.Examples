namespace Catel.Examples.Validation
{
    using System.Windows;
    using Data;
    using IoC;
    using Logging;
    using Validation;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // TODO: Using a custom IoC container like Unity? Register it here:
            // Catel.IoC.ServiceLocator.Instance.RegisterExternalContainer(MyUnityContainer);

            LogManager.AddDebugListener();

            var serviceLocator = IoC.ServiceLocator.Default;

            // Initialize composite validator provider to enable multiple validator sources
            var provider = new CompositeValidatorProvider();
            provider.Add(new ValidatorProvider());

            // serviceLocator.RegisterType<IValidatorProvider, ValidatorProvider>();
            serviceLocator.RegisterInstance<IValidatorProvider>(provider);

            base.OnStartup(e);
        }
        #endregion
    }
}