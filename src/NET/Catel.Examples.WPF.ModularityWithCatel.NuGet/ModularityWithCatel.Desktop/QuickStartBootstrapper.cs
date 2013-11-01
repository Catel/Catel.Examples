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
   
    using IModuleTracker = ModuleTracking.IModuleTracker;

    /// <summary>
    /// Initializes Prism to start this quickstart Prism application to use Unity.
    /// </summary>
    public class QuickStartBootstrapper : BootstrapperBase<Shell, CompositeModuleCatalog>
    {
        #region Fields
        /// <summary>
        /// The callback logger.
        /// </summary>
        private readonly CallbackLogger _callbackLogger = new CallbackLogger();
        #endregion

        #region Methods
        /// <summary>
        /// Configures the <see cref="IServiceLocator"/>. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeIfNotYetRegistered<IModuleTracker, ModuleTracker>();

            LogManager.AddListener(_callbackLogger);
            Container.RegisterInstance<CallbackLogger>(_callbackLogger);
        }

        /// <summary>
        /// The configure module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = new NuGetBasedModuleCatalog 
            {
                AllowPrereleaseVersions = true,
            };

            // Module A is defined from NuGet.
            moduleCatalog.AddModule(new ModuleInfo("ModuleA", "ModularityWithCatel.Desktop.ModuleA, ModularityWithCatel.Desktop.ModuleA") { Ref = "ModularityWithCatel.Desktop.ModuleA" });
            
            // Module C is defined from NuGet.
            moduleCatalog.AddModule(new ModuleInfo("ModuleC", "ModularityWithCatel.Desktop.ModuleC, ModularityWithCatel.Desktop.ModuleC") { Ref = "ModularityWithCatel.Desktop.ModuleC", InitializationMode = InitializationMode.OnDemand });
            
            ModuleCatalog.Add(moduleCatalog);
            
            // Module B and Module D are copied to a directory as part of a post-build step.
            // These modules are not referenced in the project and are discovered by inspecting a directory.
            // Both projects have a post-build step to copy themselves into that directory.
            var directoryCatalog = new DirectoryModuleCatalog { ModulePath = @".\DirectoryModules" };
            ModuleCatalog.Add(directoryCatalog);

            // Module E and Module F are defined in configuration.
            var configurationCatalog = new ConfigurationModuleCatalog();
            ModuleCatalog.Add(configurationCatalog);
        }
        #endregion
    }
}