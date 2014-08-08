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
    }
}