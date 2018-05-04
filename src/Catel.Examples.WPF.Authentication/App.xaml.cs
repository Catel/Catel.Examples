// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Authentication
{
    using System.Windows;
    using IoC;
    using MVVM;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<IAuthenticationProvider, AuthenticationProvider>();
        }
    }
}