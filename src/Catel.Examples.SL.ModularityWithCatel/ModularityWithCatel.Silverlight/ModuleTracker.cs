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

    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.Modularity;

    using ModuleTracking;

    using IModuleTracker = ModuleTracking.IModuleTracker;

    /// <summary>
    /// Provides tracking of modules for the quickstart.
    /// </summary>
    /// <remarks>
    /// This class is for demonstration purposes for the quickstart and not expected to be used in a real world application.
    /// This class exports the interface for modules and the concrete type for the shell.    
    /// </remarks>
    public class ModuleTracker : IModuleTracker
    {
        #region Fields

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILoggerFacade logger;

        /// <summary>
        /// The module a tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleATrackingState;

        /// <summary>
        /// The module b tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleBTrackingState;

        /// <summary>
        /// The module c tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleCTrackingState;

        /// <summary>
        /// The module d tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleDTrackingState;

        /// <summary>
        /// The module e tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleETrackingState;

        /// <summary>
        /// The module f tracking state.
        /// </summary>
        private readonly ModuleTrackingState moduleFTrackingState;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleTracker"/> class. 
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="logger"/> is <c>null</c>.</exception>
        public ModuleTracker(ILoggerFacade logger)
        {
            Argument.IsNotNull("logger", logger);

            this.logger = logger;

            // These states are defined specifically for the Silverlight version of the quickstart.
            moduleATrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleA, ExpectedDiscoveryMethod = DiscoveryMethod.ApplicationReference, ExpectedInitializationMode = InitializationMode.WhenAvailable, ExpectedDownloadTiming = DownloadTiming.WithApplication, ConfiguredDependencies = WellKnownModuleNames.ModuleD, };
            moduleBTrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleB, ExpectedDiscoveryMethod = DiscoveryMethod.XamlManifest, ExpectedInitializationMode = InitializationMode.WhenAvailable, ExpectedDownloadTiming = DownloadTiming.InBackground, };
            moduleCTrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleC, ExpectedDiscoveryMethod = DiscoveryMethod.ApplicationReference, ExpectedInitializationMode = InitializationMode.OnDemand, ExpectedDownloadTiming = DownloadTiming.WithApplication, };
            moduleDTrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleD, ExpectedDiscoveryMethod = DiscoveryMethod.XamlManifest, ExpectedInitializationMode = InitializationMode.WhenAvailable, ExpectedDownloadTiming = DownloadTiming.InBackground, };
            moduleETrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleE, ExpectedDiscoveryMethod = DiscoveryMethod.XamlManifest, ExpectedInitializationMode = InitializationMode.OnDemand, ExpectedDownloadTiming = DownloadTiming.InBackground, };
            moduleFTrackingState = new ModuleTrackingState { ModuleName = WellKnownModuleNames.ModuleF, ExpectedDiscoveryMethod = DiscoveryMethod.XamlManifest, ExpectedInitializationMode = InitializationMode.OnDemand, ExpectedDownloadTiming = DownloadTiming.InBackground, ConfiguredDependencies = WellKnownModuleNames.ModuleE, };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the tracking state of module A.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleATrackingState
        {
            get { return moduleATrackingState; }
        }

        /// <summary>
        /// Gets the tracking state of module B.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleBTrackingState
        {
            get { return moduleBTrackingState; }
        }

        /// <summary>
        /// Gets the tracking state of module C.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleCTrackingState
        {
            get { return moduleCTrackingState; }
        }

        /// <summary>
        /// Gets the tracking state of module D.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleDTrackingState
        {
            get { return moduleDTrackingState; }
        }

        /// <summary>
        /// Gets the tracking state of module E.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleETrackingState
        {
            get { return moduleETrackingState; }
        }

        /// <summary>
        /// Gets the tracking state of module F.
        /// </summary>
        /// <value>A ModuleTrackingState.</value>
        /// <remarks>
        /// This is exposed as a specific property for data-binding purposes in the quickstart UI.
        /// </remarks>
        public ModuleTrackingState ModuleFTrackingState
        {
            get { return moduleFTrackingState; }
        }

        #endregion

        #region IModuleTracker Members

        /// <summary>
        /// Records the module has been constructed.
        /// </summary>
        /// <param name="moduleName">
        /// The <see cref="WellKnownModuleNames">well-known name</see> of the module.
        /// </param>
        public void RecordModuleConstructed(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Constructed;
            }

            logger.Log(string.Format("'{0}' module constructed.", moduleName), Category.Debug, Priority.Low);
        }

        /// <summary>
        /// Records the module is loading.
        /// </summary>
        /// <param name="moduleName">
        /// The <see cref="WellKnownModuleNames">well-known name</see> of the module.
        /// </param>
        /// <param name="bytesReceived">
        /// The number of bytes downloaded.
        /// </param>
        /// <param name="totalBytesToReceive">
        /// The total Bytes To Receive.
        /// </param>
        public void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive)
        {
            ModuleTrackingState moduleTrackingState = GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.BytesReceived = bytesReceived;
                moduleTrackingState.TotalBytesToReceive = totalBytesToReceive;

                if (bytesReceived < totalBytesToReceive)
                {
                    moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Downloading;
                }
                else
                {
                    moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Downloaded;
                }
            }

            logger.Log(string.Format("'{0}' module is loading {1}/{2} bytes.", moduleName, bytesReceived, totalBytesToReceive), Category.Debug, Priority.Low);
        }

        /// <summary>
        /// Records the module has been initialized.
        /// </summary>
        /// <param name="moduleName">
        /// The <see cref="WellKnownModuleNames">well-known name</see> of the module.
        /// </param>
        public void RecordModuleInitialized(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Initialized;
            }

            logger.Log(string.Format("{0} module initialized.", moduleName), Category.Debug, Priority.Low);
        }

        /// <summary>
        /// Records the module is loaded.
        /// </summary>
        /// <param name="moduleName">
        /// The <see cref="WellKnownModuleNames">well-known name</see> of the module.
        /// </param>
        public void RecordModuleLoaded(string moduleName)
        {
            logger.Log(string.Format("'{0}' module loaded.", moduleName), Category.Debug, Priority.Low);
        }

        #endregion

        // A helper to make updating specific property instances by name easier.
        #region Methods

        /// <summary>
        /// The get module tracking state.
        /// </summary>
        /// <param name="moduleName">
        /// The module name.
        /// </param>
        /// <returns>
        /// </returns>
        private ModuleTrackingState GetModuleTrackingState(string moduleName)
        {
            switch (moduleName)
            {
                case WellKnownModuleNames.ModuleA:
                    return ModuleATrackingState;
                case WellKnownModuleNames.ModuleB:
                    return ModuleBTrackingState;
                case WellKnownModuleNames.ModuleC:
                    return ModuleCTrackingState;
                case WellKnownModuleNames.ModuleD:
                    return ModuleDTrackingState;
                case WellKnownModuleNames.ModuleE:
                    return ModuleETrackingState;
                case WellKnownModuleNames.ModuleF:
                    return ModuleFTrackingState;
                default:
                    return null;
            }
        }

        #endregion
    }
}