namespace Catel.Examples.WPF.Prism.Modules.Employees
{
    using Catel.Modules;
    using Microsoft.Practices.Prism.Regions;

    public class EmployeesModule : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesModule"/> class.
        /// </summary>
        public EmployeesModule()
            : base(WellKnownModuleNames.EmployeesModule)
        {
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            RegionManager.RegisterViewWithRegion("EmployeesRegion", typeof(Views.EmployeesView));
        }
    }
}