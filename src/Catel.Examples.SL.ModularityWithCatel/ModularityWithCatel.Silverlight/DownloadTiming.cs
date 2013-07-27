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
    /// <summary>
    /// Describes when a module is downloaded.
    /// </summary>
    public enum DownloadTiming
    {
        /// <summary>
        /// The module is downloaded with the application.
        /// </summary>
        WithApplication,

        /// <summary>
        /// The module is downloaded in the background either after the application starts, or on-demand.
        /// </summary>
        InBackground
    }
}