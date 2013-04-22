// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.WPF.Prism
{
    using Models;
    using Views;
    using IoC;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The bootstrapper.
    /// </summary>
    public class Bootstrapper : BootstrapperBase<ShellView, ConfigurationModuleCatalog>
    {
        #region Method Overrides
        /// <summary>
        /// Configures the <see cref="IUnityContainer"/>. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            Container.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }

        /// <summary>
        /// Configures the <see cref="T:Microsoft.Practices.Prism.Modularity.IModuleCatalog"/> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog.Initialize();
        }

        /// <summary>
        /// Configures the default region adapter mappings to use in the application, in order 
        /// to adapt UI controls defined in XAML to use a region and register it automatically.
        /// </summary>
        /// <returns>
        /// The RegionAdapterMappings instance containing all the mappings.
        /// </returns>
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // Call base method
            var mappings = base.ConfigureRegionAdapterMappings();
            return ObjectHelper.IsNull(mappings) ? null : mappings;
        }
        #endregion
    }
}