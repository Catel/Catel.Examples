// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehaviorsWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.AdvancedDemo.Views
{
    using ViewModels;
    using Windows;

    /// <summary>
    /// Interaction logic for BehaviorsWindow.xaml
    /// </summary>
    public partial class BehaviorsWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorsWindow"/> class.
        /// </summary>
        public BehaviorsWindow()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorsWindow"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public BehaviorsWindow(BehaviorsWindowViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}