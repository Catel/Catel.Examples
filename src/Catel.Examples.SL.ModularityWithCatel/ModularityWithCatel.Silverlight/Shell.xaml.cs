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
    using System.Globalization;
    using System.Windows;

    using Catel;

    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.Modularity;

    using ModuleTracking;

    using IModuleTracker = ModuleTracking.IModuleTracker;

    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell
    {
        #region Fields

        /// <summary>
        /// The logger.
        /// </summary>
        public CallbackLogger logger;

        /// <summary>
        /// The module manager.
        /// </summary>
        public IModuleManager moduleManager;

        /// <summary>
        /// The module tracker.
        /// </summary>
        public IModuleTracker moduleTracker;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class. 
        /// </summary>
        /// <param name="moduleManager">
        /// The module Manager.
        /// </param>
        /// <param name="moduleTracker">
        /// The module Tracker.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="logger"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="moduleTracker"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// The <paramref name="moduleManager"/> is <c>null</c>.
        /// </exception>
        public Shell(IModuleManager moduleManager, IModuleTracker moduleTracker, CallbackLogger logger)
        {
            Argument.IsNotNull("moduleManager", moduleManager);
            Argument.IsNotNull("moduleTracker", moduleTracker);
            Argument.IsNotNull("logger", logger);
            this.moduleManager = moduleManager;
            this.moduleTracker = moduleTracker;
            this.logger = logger;

            // I use the IModuleTracker as the data-context for data-binding.
            // This quickstart only demonstrates modularity for Prism and does not use data-binding patterns such as MVVM.
            DataContext = this.moduleTracker;

            // I set this shell's Log method as the callback for receiving log messages.
            this.logger.Callback = Log;

            // I subscribe to events to help track module loading/loaded progress.
            // The ModuleManager uses the Async Events Pattern.
            this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this.moduleManager.ModuleDownloadProgressChanged += ModuleManager_ModuleDownloadProgressChanged;

            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Logs the specified message.  Called by the CallbackLogger.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        public void Log(string message, Category category)
        {
            TraceTextBox.Text += string.Format(CultureInfo.CurrentUICulture, "[{0}] {1}\r\n", category, message);
        }

        /// <summary>
        /// Handles the RequestModuleLoad event of the ModuleC control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void ModuleC_RequestModuleLoad(object sender, EventArgs e)
        {
            // The ModuleManager uses the Async Events Pattern.
            moduleManager.LoadModule(WellKnownModuleNames.ModuleC);
        }

        /// <summary>
        /// Handles the RequestModuleLoad event of the ModuleE control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void ModuleE_RequestModuleLoad(object sender, EventArgs e)
        {
            // The ModuleManager uses the Async Events Pattern.
            moduleManager.LoadModule(WellKnownModuleNames.ModuleE);
        }

        /// <summary>
        /// Handles the RequestModuleLoad event of the ModuleF control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        private void ModuleF_RequestModuleLoad(object sender, EventArgs e)
        {
            // The ModuleManager uses the Async Events Pattern.
            moduleManager.LoadModule(WellKnownModuleNames.ModuleF);
        }

        /// <summary>
        /// The user control_ loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            logger.ReplaySavedLogs();
        }

        /// <summary>
        /// Handles the LoadModuleProgressChanged event of the ModuleManager control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="Microsoft.Practices.Composite.Modularity.LoadModuleProgressChangedEventArgs"/> instance containing the event data.
        /// </param>
        private void ModuleManager_ModuleDownloadProgressChanged(object sender, ModuleDownloadProgressChangedEventArgs e)
        {
            moduleTracker.RecordModuleDownloading(e.ModuleInfo.ModuleName, e.BytesReceived, e.TotalBytesToReceive);
        }

        /// <summary>
        /// Handles the LoadModuleCompleted event of the ModuleManager control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="Microsoft.Practices.Composite.Modularity.LoadModuleCompletedEventArgs"/> instance containing the event data.
        /// </param>
        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            moduleTracker.RecordModuleLoaded(e.ModuleInfo.ModuleName);
        }

        #endregion
    }
}