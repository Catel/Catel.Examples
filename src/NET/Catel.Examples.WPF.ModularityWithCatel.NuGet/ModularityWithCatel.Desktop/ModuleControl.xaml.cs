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
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Modularity;

    using ModularityWithCatel.Desktop;

    /// <summary>
    /// Interaction logic for ModuleControl.xaml
    /// </summary>
    public partial class ModuleControl : UserControl
    {
        private ModuleTrackingState moduleTrackingState;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleControl"/> class.
        /// </summary>
        public ModuleControl()
        {
            this.InitializeComponent();

            this.DataContextChanged += ModuleControl_DataContextChanged;
            this.OnDataContextChanged();
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
        /// Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonUp"/> routed event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports that the left mouse button was released.</param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            if (!e.Handled)
            {
                if ((this.moduleTrackingState != null) && (this.moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand) && (moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
                {
                    this.RaiseRequestModuleLoad();
                    e.Handled = true;
                }
            }
        }

        private void UpdateClickToLoadTextBlockVisibility()
        {
            if ((this.moduleTrackingState != null)
                && (this.moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand)
                && (this.moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
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
            if ((this.moduleTrackingState != null)
                && (this.moduleTrackingState.ExpectedDownloadTiming == DownloadTiming.InBackground)
                && (this.moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.Downloading))
            {
                this.LoadProgressPanel.Visibility = Visibility.Visible;
            }
            else
            {
                this.LoadProgressPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void ModuleControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateClickToLoadTextBlockVisibility();
            this.UpdateLoadProgressTextBlockVisibility();            
        }

        void ModuleControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.OnDataContextChanged();
        }

        private void OnDataContextChanged()
        {
            if (this.moduleTrackingState != null)
            {
                this.moduleTrackingState.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModuleTrackingState_PropertyChanged);
            }

            this.moduleTrackingState = this.DataContext as ModuleTrackingState;

            if (this.moduleTrackingState != null)
            {
                this.moduleTrackingState.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModuleTrackingState_PropertyChanged);
            }

            this.UpdateClickToLoadTextBlockVisibility();
            this.UpdateLoadProgressTextBlockVisibility();     
        }

        void ModuleTrackingState_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.UpdateClickToLoadTextBlockVisibility();
            this.UpdateLoadProgressTextBlockVisibility();
        }
    }
}
