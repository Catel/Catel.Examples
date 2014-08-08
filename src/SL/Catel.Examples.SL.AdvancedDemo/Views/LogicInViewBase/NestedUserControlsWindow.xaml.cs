// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedUserControlsWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo.Views.LogicInViewBase
{
    using ViewModels;
    using Windows;

    /// <summary>
    /// Interaction logic for NestedUserControlsWindow.xaml
    /// </summary>
    public partial class NestedUserControlsWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedUserControlsWindow"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public NestedUserControlsWindow(NestedUserControlsWindowViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedUserControlsWindow"/> class.
        /// </summary>
        public NestedUserControlsWindow()
            : this(null)
        {
        }
    }
}