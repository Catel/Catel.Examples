// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.WPF.MvvmCommunicationStyles
{
    using System.Windows;
    using IoC;
    using Messaging;
    using Windows;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            //Catel.Logging.LogManager.RegisterDebugListener();
#endif

            StyleHelper.CreateStyleForwardersForDefaultStyles();

            base.OnStartup(e);
        }
    }
}