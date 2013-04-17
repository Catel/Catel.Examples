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
namespace ModularityWithCatel.Desktop
{
    /// <summary>
    /// Describes how a module is discovered.
    /// </summary>
    public enum DiscoveryMethod
    {
        /// <summary>
        /// The module is directly referenced by the application.
        /// </summary>
        ApplicationReference,

        /// <summary>
        /// The module is listed in a XAML manifest file.
        /// </summary>
        XamlManifest,

        /// <summary>
        /// The module is listed in a configuration file.
        /// </summary>
        ConfigurationManifest,

        /// <summary>
        /// The module is discovered by examining the assemblies in a directory.
        /// </summary>
        DirectorySweep
    }
}