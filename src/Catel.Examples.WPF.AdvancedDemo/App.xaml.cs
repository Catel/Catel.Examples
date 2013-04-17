// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo
{
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;
    using IoC;
    using MVVM;
    using Microsoft.Practices.Unity;
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
            Logging.LogManager.RegisterDebugListener();

            StyleHelper.CreateStyleForwardersForDefaultStyles();

            var serviceLocator = ServiceLocator.Default;

            serviceLocator.RegisterType<IViewLocator, ViewLocator>();
            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.NamingConventions.Add("[UP].Views.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]Window");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]Window");

            serviceLocator.RegisterType<IViewModelLocator, ViewModelLocator>();
            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.NamingConventions.Add("Catel.Examples.AdvancedDemo.ViewModels.[VW]ViewModel");

            // Register several different external IoC containers for demo purposes
            IoCHelper.MefContainer = new CompositionContainer();
            IoCHelper.UnityContainer = new UnityContainer();
            serviceLocator.RegisterExternalContainer(IoCHelper.MefContainer);
            serviceLocator.RegisterExternalContainer(IoCHelper.UnityContainer);

            base.OnStartup(e);
        }
    }
}