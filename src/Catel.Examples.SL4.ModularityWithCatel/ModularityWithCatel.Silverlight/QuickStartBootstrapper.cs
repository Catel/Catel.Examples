//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
namespace ModularityWithCatel.Silverlight
{
    using System;

    using Catel;
    using Catel.IoC;
    using Catel.Logging;

    using Microsoft.Practices.Prism.Modularity;

    using ModuleTracking;

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
        private readonly CallbackLogger callbackLogger = new CallbackLogger();

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

            LogManager.AddListener(callbackLogger);

            Container.RegisterInstance<CallbackLogger>(callbackLogger);
        }

        /// <summary>
        /// Creates the <see cref="IModuleCatalog"/> used by Prism.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The base implementation returns a new ModuleCatalog.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return Catel.Modules.DownloadingModuleCatalog.CreateFromXaml(new Uri("/ModularityWithCatel.Silverlight;component/ModulesCatalog.xaml", UriKind.Relative));

            // Module B, D, E and F are defined in XAML.
            //return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/ModularityWithCatel.Silverlight;component/ModulesCatalog.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Configures the <see cref="IModuleCatalog"/> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            // Module A is defined in the code.
            Type moduleAType = typeof(ModuleA.ModuleA);
            ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName, WellKnownModuleNames.ModuleD));

            // Module C is defined in the code.
            Type moduleCType = typeof(ModuleC.ModuleC);
            ModuleCatalog.AddModule(new ModuleInfo { ModuleName = moduleCType.Name, ModuleType = moduleCType.AssemblyQualifiedName, InitializationMode = InitializationMode.OnDemand });
        }

        #endregion
    }
}