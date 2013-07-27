// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterestedInWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.Views
{
    using ViewModels;
    using Windows;

    /// <summary>
    /// Interaction logic for InterestedInWindow.xaml.
    /// </summary>
    public partial class InterestedInWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedInWindow"/> class.
        /// </summary>
        public InterestedInWindow()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterestedInWindow"/> class.
        /// </summary>
        /// <param name="viewModel">
        /// The view model to inject.
        /// </param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public InterestedInWindow(InterestedInViewModel viewModel)
            : base(viewModel, DataWindowMode.Close)
        {
            InitializeComponent();
        }
    }
}