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
namespace ModuleA
{
    using System;
    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.Modularity;
    using ModuleTracking;

    /// <summary>
    /// A module for the quickstart.
    /// </summary>   
    public class ModuleA : IModule
    {
        private ILoggerFacade logger;
        private IModuleTracker moduleTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleA"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="moduleTracker">The module tracker.</param>
        public ModuleA(ILoggerFacade logger, IModuleTracker moduleTracker)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }

            this.logger = logger;
            this.moduleTracker = moduleTracker;
            this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleA);
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            this.logger.Log("ModuleA demonstrates logging during Initialize().", Category.Info, Priority.Medium);
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.ModuleA);
        }
    }
}
