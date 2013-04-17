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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Modularity;

    /// <summary>
    /// Interaction logic for ModuleControl.xaml
    /// </summary>
    public partial class ModuleControl : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleControl"/> class.
        /// </summary>
        public ModuleControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Raised when the user clicks to load the module.
        /// </summary>
        public event EventHandler RequestModuleLoad;

        private void RaiseRequestModuleLoad()
        {
            if (this.RequestModuleLoad != null)
            {
                this.RequestModuleLoad(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called before the <see cref="E:System.Windows.UIElement.MouseLeftButtonUp"/> event occurs.
        /// </summary>
        /// <param name="e">The data for the event.</param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (!e.Handled)
            {
                ModuleTrackingState moduleTrackingState = this.DataContext as ModuleTrackingState;
                if ((moduleTrackingState != null) && (moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand) && (moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
                {
                    this.RaiseRequestModuleLoad();
                    e.Handled = true;
                }
            }
        }

        private void UpdateClickToLoadTextBlockVisibility()
        {
            ModuleTrackingState moduleTrackingState = this.DataContext as ModuleTrackingState;
            if ((moduleTrackingState != null) 
                && (moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand) 
                && (moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
            {
                this.ClickToLoadTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                this.ClickToLoadTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateLoadProgressTextBlockVisibility()
        {
            ModuleTrackingState moduleTrackingState = this.DataContext as ModuleTrackingState;
            if ((moduleTrackingState != null)
                && (moduleTrackingState.ExpectedDownloadTiming == DownloadTiming.InBackground)
                && (moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.Downloading))
            {
                this.LoadProgressPanel.Visibility = Visibility.Visible;
            }
            else
            {
                this.LoadProgressPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateClickToLoadTextBlockVisibility();
            this.UpdateLoadProgressTextBlockVisibility();

            ModuleTrackingState moduleTrackingState = this.DataContext as ModuleTrackingState;
            if (moduleTrackingState != null)
            {
                moduleTrackingState.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModuleTrackingState_PropertyChanged);
            }
        }

        void ModuleTrackingState_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.UpdateClickToLoadTextBlockVisibility();
            this.UpdateLoadProgressTextBlockVisibility();
        }
    }
}
