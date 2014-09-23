// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomView.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo.Views.LogicInBehavior
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using Catel.MVVM.Views;
    using Catel.Windows.Data;
    using MVVM;

    /// <summary>
    /// Interaction logic for RoomView.xaml.
    /// </summary>
    /// <remarks>
    /// The <see cref="IViewModelContainer"/> is implemented to enable chained user controls for validation. This
    /// means that only the top-level view model has to invoke Validate to validate all child view models.
    /// </remarks>
    public partial class RoomView : UserControl, IView
    {
        private event EventHandler<EventArgs> _viewLoaded;
        private event EventHandler<EventArgs> _viewUnloaded;
        private event EventHandler<DataContextChangedEventArgs> _viewDataContextChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomView"/> class.
        /// </summary>
        public RoomView()
        {
            InitializeComponent();

            mvvmBehavior.ViewModelChanged += (sender, e) => ViewModelChanged.SafeInvoke(this, e);
            mvvmBehavior.ViewModelPropertyChanged += (sender, e) => ViewModelPropertyChanged.SafeInvoke(this, e);
            mvvmBehavior.ViewLoading += (sender, e) => ViewLoading.SafeInvoke(this);
            mvvmBehavior.ViewLoaded += (sender, e) => ViewLoaded.SafeInvoke(this);
            mvvmBehavior.ViewUnloading += (sender, e) => ViewUnloading.SafeInvoke(this);
            mvvmBehavior.ViewUnloaded += (sender, e) => ViewUnloaded.SafeInvoke(this);

            Loaded += (sender, e) => _viewLoaded.SafeInvoke(this, EventArgs.Empty);
            Unloaded += (sender, e) => _viewUnloaded.SafeInvoke(this, EventArgs.Empty);

            this.SubscribeToDataContextAndInheritedDataContext(OnDataContextChanged);
            this.SubscribeToAllDependencyProperties(OnDependencyPropertyChanged);
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
        /// Gets or sets a value indicating whether the view model container should prevent the creation of a view model.
        /// <para />
        /// This property is very useful when using views in transitions where the view model is no longer required.
        /// </summary>
        /// <value><c>true</c> if the view model container should prevent view model creation; otherwise, <c>false</c>.</value>
        public bool PreventViewModelCreation
        {
            get { return mvvmBehavior.PreventViewModelCreation; }
            set { mvvmBehavior.PreventViewModelCreation = value; }
        }

        /// <summary>
        /// Occurs when a property on the container has changed.
        /// </summary>
        /// <remarks>
        /// This event makes it possible to externally subscribe to property changes of a <see cref="DependencyObject"/>
        /// (mostly the container of a view model) because the .NET Framework does not allows us to.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the <see cref="ViewModel"/> property has changed.
        /// </summary>
        public event EventHandler<EventArgs> ViewModelChanged;

        /// <summary>
        /// Occurs when a property on the <see cref="P:Catel.MVVM.IViewModelContainer.ViewModel"/> has changed.
        /// </summary>
        public event EventHandler<PropertyChangedEventArgs> ViewModelPropertyChanged;

        /// <summary>
        /// Occurs when the view model container is loading.
        /// </summary>
        public event EventHandler<EventArgs> ViewLoading;

        /// <summary>
        /// Occurs when the view model container is loaded.
        /// </summary>
        public event EventHandler<EventArgs> ViewLoaded;

        /// <summary>
        /// Occurs when the view model container starts unloading.
        /// </summary>
        public event EventHandler<EventArgs> ViewUnloading;

        /// <summary>
        /// Occurs when the view model container is unloaded.
        /// </summary>
        public event EventHandler<EventArgs> ViewUnloaded;

        /// <summary>
        /// Occurs when the view is loaded.
        /// </summary>
        event EventHandler<EventArgs> IView.Loaded
        {
            add { _viewLoaded += value; }
            remove { _viewLoaded -= value; }
        }

        /// <summary>
        /// Occurs when the view is unloaded.
        /// </summary>
        event EventHandler<EventArgs> IView.Unloaded
        {
            add { _viewUnloaded += value; }
            remove { _viewUnloaded -= value; }
        }

        /// <summary>
        /// Occurs when the data context has changed.
        /// </summary>
        event EventHandler<DataContextChangedEventArgs> IView.DataContextChanged
        {
            add { _viewDataContextChanged += value; }
            remove { _viewDataContextChanged -= value; }
        }

        private void OnDataContextChanged(object sender, DependencyPropertyValueChangedEventArgs e)
        {
            _viewDataContextChanged.SafeInvoke(this, new DataContextChangedEventArgs(e.OldValue, e.NewValue));
        }

        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this <see cref="T:System.Windows.FrameworkElement"/> has been updated. The specific dependency property that changed is reported in the arguments parameter. Overrides <see cref="M:System.Windows.DependencyObject.OnPropertyChanged(System.Windows.DependencyPropertyChangedEventArgs)"/>.
        /// </summary>
        /// <param name="e">The event data that describes the property that changed, as well as old and new values.</param>
        private void OnDependencyPropertyChanged(object sender, DependencyPropertyValueChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(e.PropertyName));
            }
        }
    }
}