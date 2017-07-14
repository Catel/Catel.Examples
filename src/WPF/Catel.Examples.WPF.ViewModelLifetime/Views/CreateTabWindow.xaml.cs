// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTabWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.ViewModelLifetime.Views
{
    using MVVM;

    public partial class CreateTabWindow
    {
        #region Constructors
        public CreateTabWindow()
            : this(null)
        {
        }

        public CreateTabWindow(IViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
        #endregion
    }
}