// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Validation
{
    using System.Windows;
    using Data;
    using IoC;
    using Logging;
    using Validation;
    using Windows;

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
            StyleHelper.CreateStyleForwardersForDefaultStyles();

            // TODO: Using a custom IoC container like Unity? Register it here:
            // Catel.IoC.ServiceLocator.Instance.RegisterExternalContainer(MyUnityContainer);

            LogManager.RegisterDebugListener();

            var serviceLocator = IoC.ServiceLocator.Default;

            // Initialize composite validator provider to enable multiple validator sources
            var provider = new CompositeValidatorProvider();
            provider.Add(new ValidatorProvider());
            provider.Add(new FluentValidatorProvider());

            // serviceLocator.RegisterType<IValidatorProvider, ValidatorProvider>();
            serviceLocator.RegisterInstance<IValidatorProvider>(provider);

            base.OnStartup(e);
        }
    }
}