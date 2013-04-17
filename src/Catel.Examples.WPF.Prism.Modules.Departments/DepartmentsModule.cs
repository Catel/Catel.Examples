namespace Catel.Examples.WPF.Prism.Modules.Departments
{
    using Catel.Modules;
    using Microsoft.Practices.Prism.Regions;
    using Services;
    using Views;

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