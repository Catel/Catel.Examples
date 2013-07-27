// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationBarView.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Prism.Modules.Departments.Views
{
    /// <summary>
    /// Interaction logic for NotificationBarView.xaml.
    /// </summary>
    public partial class NotificationBarView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationBarView"/> class.
        /// </summary>
        public NotificationBarView()
        {
            InitializeComponent();
            CloseViewModelOnUnloaded = false;
        }
    }
}