// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DemoWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo.Views.LogicInViewBase
{
    using ViewModels;
    using Windows;

    /// <summary>
    /// Interaction logic for DemoWindow.xaml
    /// </summary>
    public partial class DemoWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoWindow"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public DemoWindow(DemoWindowViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoWindow"/> class.
        /// </summary>
        public DemoWindow()
            : this(null)
        {
        }

        /// <summary>
        /// Gets the type of the view model. If this method returns <c>null</c>, the view model type will be retrieved by naming
        /// convention using the <see cref="T:Catel.MVVM.IViewModelLocator"/> registered in the <see cref="T:Catel.IoC.IServiceLocator"/>.
        /// </summary>
        /// <returns>The type of the view model or <c>null</c> in case it should be auto determined.</returns>
        /// <remarks></remarks>
        protected override System.Type GetViewModelType()
        {
            return typeof (ViewModels.DemoWindowViewModel);
        }
    }
}