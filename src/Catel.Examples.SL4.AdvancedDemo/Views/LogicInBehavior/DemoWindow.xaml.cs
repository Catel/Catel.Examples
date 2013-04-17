// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DemoWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo.Views.LogicInBehavior
{
    using System;
    using System.ComponentModel;
    using System.Windows.Controls;
    using MVVM;

    /// <summary>
    /// Interaction logic for DemoWindow.xaml.
    /// </summary>
    /// <remarks>
    /// The <see cref="IViewModelContainer"/> is implemented to enable chained user controls for validation. This
    /// means that only the top-level view model has to invoke Validate to validate all child view models.
    /// </remarks>
    public partial class DemoWindow : ChildWindow, IViewModelContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoWindow"/> class.
        /// </summary>
        public DemoWindow()
        {
            InitializeComponent();

            mvvmBehavior.ViewModelChanged += (sender, e) => ViewModelChanged.SafeInvoke(this, e);
            mvvmBehavior.ViewModelPropertyChanged += (sender, e) => ViewModelPropertyChanged.SafeInvoke(this, e);
            mvvmBehavior.TargetControlPropertyChanged += (sender, e) => PropertyChanged.SafeInvoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        /// <summary>
        /// Gets the view model that is contained by the container.
        /// </summary>
        /// <value>The view model.</value>
        public IViewModel ViewModel
        {
            get { return mvvmBehavior.ViewModel; }
        }

        /// <summary>
        /// Occurs when the <see cref="ViewModel"/> property has changed.
        /// </summary>
        public event EventHandler<EventArgs> ViewModelChanged;

        /// <summary>
        /// Occurs when a property on the current <see cref="ViewModel"/> has changed.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> ViewModelPropertyChanged;

        /// <summary>
        /// Occurs when a property on the container has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}