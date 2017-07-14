// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrottlingWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Behaviors.Views
{
    using Windows;
    using ViewModels;

    public partial class ThrottlingWindow
    {
        #region Constructors
        public ThrottlingWindow()
            : this(null)
        {
        }

        public ThrottlingWindow(ThrottlingViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
        #endregion
    }
}