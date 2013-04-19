// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMediatorWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.Views
{
    using ViewModels;
    using Windows;

    /// <summary>
    /// Interaction logic for MessageMediatorWindow.xaml.
    /// </summary>
    public partial class MessageMediatorWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMediatorWindow"/> class.
        /// </summary>
        public MessageMediatorWindow()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMediatorWindow"/> class.
        /// </summary>
        /// <param name="viewModel">
        /// The view model to inject.
        /// </param>
        /// <remarks>
        /// This constructor can be used to use view-model injection.
        /// </remarks>
        public MessageMediatorWindow(MessageMediatorViewModel viewModel)
            : base(viewModel, DataWindowMode.Close)
        {
            InitializeComponent();
        }
    }
}