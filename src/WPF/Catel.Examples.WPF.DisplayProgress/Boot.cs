// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Boot.cs" company="Catel development team">
//   Copyright (c) 2008 - 2014 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.DisplayProgress
{
    using Views;

#if SILVERLIGHT
    using IoC;
    using Services;
#endif

    /// <summary>
    ///     The boot.
    /// </summary>
    public class Boot : BootstrapperBase<MainWindow>
    {
#if SILVERLIGHT

        /// <summary>
        /// The configure container.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IPleaseWaitService, PleaseWaitService>(RegistrationType.Transient);
        }

#endif
    }
}