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
namespace ModuleTracking
{
    /// <summary>
    /// Provides ability for modules to inform the quickstart of their state.
    /// </summary>
    public interface IModuleTracker
    {
        /// <summary>
        /// Records the module is loading.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        /// <param name="bytesReceived">The number of bytes downloaded.</param>
        void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive);

        /// <summary>
        /// Records the module has been loaded.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        void RecordModuleLoaded(string moduleName);

        /// <summary>
        /// Records the module has been constructed.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        void RecordModuleConstructed(string moduleName);

        /// <summary>
        /// Records the module has been initialized.
        /// </summary>
        /// <param name="moduleName">The <see cref="WellKnownModuleNames">well-known name</see> of the module.</param>
        void RecordModuleInitialized(string moduleName);
    }
}