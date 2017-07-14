// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WPF.TaskCommand
{
    using System.Windows;
    using Catel.Logging;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LogManager.AddDebugListener();
        }
        #endregion
    }
}