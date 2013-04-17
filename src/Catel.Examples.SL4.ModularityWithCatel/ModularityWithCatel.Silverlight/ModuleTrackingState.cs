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
    using System.ComponentModel;

    using Microsoft.Practices.Prism.Modularity;

    /// <summary>
    /// Provides tracking of a module's state for the quickstart.
    /// </summary>
    /// <remarks>
    /// This class is for demonstration purposes for the quickstart and not expected to be used in a real world application.
    /// </remarks>
    public class ModuleTrackingState : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The bytes received.
        /// </summary>
        private long bytesReceived;

        /// <summary>
        /// The configured dependencies.
        /// </summary>
        private string configuredDependencies = "(none)";

        /// <summary>
        /// The expected discovery method.
        /// </summary>
        private DiscoveryMethod expectedDiscoveryMethod;

        /// <summary>
        /// The expected download timing.
        /// </summary>
        private DownloadTiming expectedDownloadTiming;

        /// <summary>
        /// The expected initialization mode.
        /// </summary>
        private InitializationMode expectedInitializationMode;

        /// <summary>
        /// The module initialization status.
        /// </summary>
        private ModuleInitializationStatus moduleInitializationStatus;

        /// <summary>
        /// The module name.
        /// </summary>
        private string moduleName;

        /// <summary>
        /// The total bytes to receive.
        /// </summary>
        private long totalBytesToReceive;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the module.
        /// </summary>
        /// <value>A string.</value>
        /// <remarks>
        /// This is a display string.
        /// </remarks>
        public string ModuleName
        {
            get { return moduleName; }
            set
            {
                if (moduleName != value)
                {
                    moduleName = value;
                    RaisePropertyChanged(PropertyNames.ModuleName);
                }
            }
        }

        /// <summary>
        /// Gets or sets the current initialization status of the module.
        /// </summary>
        /// <value>A ModuleInitializationStatus value.</value>
        public ModuleInitializationStatus ModuleInitializationStatus
        {
            get { return moduleInitializationStatus; }
            set
            {
                if (moduleInitializationStatus != value)
                {
                    moduleInitializationStatus = value;
                    RaisePropertyChanged(PropertyNames.ModuleInitializationStatus);
                }
            }
        }

        /// <summary>
        /// Gets or sets how the module is expected to be discovered.
        /// </summary>
        /// <value>A DiscoveryMethod value.</value>
        /// <remarks>
        /// The actual discovery method is determined by the ModuleCatalog.
        /// </remarks>
        public DiscoveryMethod ExpectedDiscoveryMethod
        {
            get { return expectedDiscoveryMethod; }
            set
            {
                if (expectedDiscoveryMethod != value)
                {
                    expectedDiscoveryMethod = value;
                    RaisePropertyChanged(PropertyNames.ExpectedDiscoveryMethod);
                }
            }
        }

        /// <summary>
        /// Gets or sets how the module is expected to be initialized.
        /// </summary>
        /// <value>An InitializationModev value.</value>
        /// <remarks>
        /// The actual initialization mode is determiend by the ModuleCatalog.
        /// </remarks>
        public InitializationMode ExpectedInitializationMode
        {
            get { return expectedInitializationMode; }
            set
            {
                if (expectedInitializationMode != value)
                {
                    expectedInitializationMode = value;
                    RaisePropertyChanged(PropertyNames.ExpectedInitializationMode);
                }
            }
        }

        /// <summary>
        /// Gets or sets how the module is expected to be downloaded.
        /// </summary>
        /// <value>A DownloadTiming value.</value>
        /// <remarks>
        /// The actual download timing is determiend by the ModuleCatalog.
        /// </remarks>        
        public DownloadTiming ExpectedDownloadTiming
        {
            get { return expectedDownloadTiming; }
            set
            {
                if (expectedDownloadTiming != value)
                {
                    expectedDownloadTiming = value;
                    RaisePropertyChanged(PropertyNames.ExpectedDownloadTiming);
                }
            }
        }

        /// <summary>
        /// Gets or sets the list of modules the module depends on.
        /// </summary>
        /// <value>A string description of module dependencies.</value>
        /// <remarks>
        /// This is a display string.
        /// </remarks>
        public string ConfiguredDependencies
        {
            get { return configuredDependencies; }
            set
            {
                if (configuredDependencies != value)
                {
                    configuredDependencies = value;
                    RaisePropertyChanged(PropertyNames.ConfiguredDependencies);
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes received as the module is loaded.
        /// </summary>
        /// <value>A number of bytes.</value>
        public long BytesReceived
        {
            get { return bytesReceived; }
            set
            {
                if (bytesReceived != value)
                {
                    bytesReceived = value;
                    RaisePropertyChanged(PropertyNames.BytesReceived);
                    RaisePropertyChanged(PropertyNames.DownloadProgressPercentage);
                }
            }
        }

        /// <summary>
        /// Gets or sets the total bytes to receive to load the module.
        /// </summary>
        /// <value>A number of bytes.</value>
        public long TotalBytesToReceive
        {
            get { return totalBytesToReceive; }
            set
            {
                if (totalBytesToReceive != value)
                {
                    totalBytesToReceive = value;
                    RaisePropertyChanged(PropertyNames.TotalBytesToReceive);
                    RaisePropertyChanged(PropertyNames.DownloadProgressPercentage);
                }
            }
        }

        /// <summary>
        /// Gets the percentage of BytesReceived/TotalByteToReceive.
        /// </summary>
        /// <value>A percentage number between 0 and 100.</value>
        public int DownloadProgressPercentage
        {
            get
            {
                if (bytesReceived < totalBytesToReceive)
                {
                    return (int)(bytesReceived * 100.0 / totalBytesToReceive);
                }
                else
                {
                    return 100;
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Nested type: PropertyNames

        /// <summary>
        /// Property names used with INotifyPropertyChanged.
        /// </summary>
        public static class PropertyNames
        {
            #region Constants

            /// <summary>
            /// The module name.
            /// </summary>
            public const string ModuleName = "ModuleName";

            /// <summary>
            /// The module initialization status.
            /// </summary>
            public const string ModuleInitializationStatus = "ModuleInitializationStatus";

            /// <summary>
            /// The expected discovery method.
            /// </summary>
            public const string ExpectedDiscoveryMethod = "ExpectedDiscoveryMethod";

            /// <summary>
            /// The expected initialization mode.
            /// </summary>
            public const string ExpectedInitializationMode = "ExpectedInitializationMode";

            /// <summary>
            /// The expected download timing.
            /// </summary>
            public const string ExpectedDownloadTiming = "ExpectedDownloadTiming";

            /// <summary>
            /// The configured dependencies.
            /// </summary>
            public const string ConfiguredDependencies = "ConfiguredDependencies";

            /// <summary>
            /// The bytes received.
            /// </summary>
            public const string BytesReceived = "BytesReceived";

            /// <summary>
            /// The total bytes to receive.
            /// </summary>
            public const string TotalBytesToReceive = "TotalBytesToReceive";

            /// <summary>
            /// The download progress percentage.
            /// </summary>
            public const string DownloadProgressPercentage = "DownloadProgressPercentage";

            #endregion
        }

        #endregion
    }
}