// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuickStartBootstrapper.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ModularityWithCatel.Desktop
{
    using Catel;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.Modules;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Unity;
    using IModuleTracker = ModuleTracking.IModuleTracker;

    /// <summary>
    /// Initializes Prism to start this quickstart Prism application to use Unity.
    /// </summary>
    public class QuickStartBootstrapper : BootstrapperBase<Shell>
    {
        #region Fields
        /// <summary>
        /// The callback logger.
        /// </summary>
        private readonly CallbackLogger _callbackLogger = new CallbackLogger();
        #endregion

        #region Methods
        /// <summary>
        /// Configures the <see cref="IUnityContainer"/>. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeIfNotYetRegistered<IModuleTracker, ModuleTracker>();

            LogManager.AddListener(_callbackLogger);
            Container.RegisterInstance(_callbackLogger);
        }

        /// <summary>
        /// Returns the module catalog that will be used to initialize the modules.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IModuleCatalog"/> that will be used to initialize the modules.
        /// </returns>
        /// <remarks>
        /// When using the default initialization behavior, this method must be overwritten by a derived class.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new CompositeModuleCatalog();
        }

        /// <summary>
        /// The configure module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            // Module A is defined in the code.
            var moduleAType = typeof (ModuleA);
            ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName));

            // Module C is defined in the code.
            var moduleCType = typeof (ModuleC);
            ModuleCatalog.AddModule(new ModuleInfo {ModuleName = moduleCType.Name, ModuleType = moduleCType.AssemblyQualifiedName, InitializationMode = InitializationMode.OnDemand});

            // Module B and Module D are copied to a directory as part of a post-build step.
            // These modules are not referenced in the project and are discovered by inspecting a directory.
            // Both projects have a post-build step to copy themselves into that directory.
            var directoryCatalog = new DirectoryModuleCatalog {ModulePath = @".\DirectoryModules"};
            ((CompositeModuleCatalog) ModuleCatalog).Add(directoryCatalog);

            // Module E and Module F are defined in configuration.
            var configurationCatalog = new ConfigurationModuleCatalog();
            ((CompositeModuleCatalog) ModuleCatalog).Add(configurationCatalog);
        }
        #endregion
    }
}