// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Boot.cs" company="">
//   
// </copyright>
// <summary>
//   The boot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.DisplayProgress
{
    using Catel;
    using Catel.Examples.DisplayProgress.Views;

#if SILVERLIGHT
    using Catel.IoC;
    using Catel.MVVM.Services;
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