// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMediatorAView.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.Views
{
    using System.Windows;
    using ViewModels;
    using Windows.Controls;

    /// <summary>
    /// Interaction logic for MessageMediatorAView.xaml.
    /// </summary>
    public partial class MessageMediatorAView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMediatorAView"/> class.
        /// </summary>
        public MessageMediatorAView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Note that this is not done via a command because it would result in false Command executed reports in the example.
        /// </summary>
        private void OnChangePropAClicked(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as CommunicationViewModel;
            if (vm != null)
            {
                vm.UpdatePropA();
            }
        }

        /// <summary>
        /// Note that this is not done via a command because it would result in false Command executed reports in the example.
        /// </summary>
        private void OnChangePropBClicked(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as CommunicationViewModel;
            if (vm != null)
            {
                vm.UpdatePropB();
            }
        }
    }
}