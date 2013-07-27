// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentsModule.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.WPF.Prism.Modules.Departments
{
    using Views;
    using Services;
    using IoC;
    using Catel.Modules;
    using Microsoft.Practices.Prism.Regions;

    /// <summary>
    /// The departments module.
    /// </summary>
    public class DepartmentsModule : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentsModule"/> class.
        /// </summary>
        public DepartmentsModule()
            : base(WellKnownModuleNames.DepartmentsModule)
        {
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            Container.RegisterType<IDepartmentTracker, DepartmentTracker>();

            RegionManager.RegisterViewWithRegion("DepartmentsRegion", typeof (DepartmentsView));
        }
    }
}