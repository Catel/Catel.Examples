// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.PersonApplication.Views
{
    using Windows;
    using ViewModels;

    public partial class PersonWindow
    {
        #region Constructors
        public PersonWindow(PersonViewModel viewModel)
            : base(viewModel, DataWindowMode.OkCancel, null, DataWindowDefaultButton.OK, true, InfoBarMessageControlGenerationMode.Inline)
        {
            AddCustomButton(new DataWindowButton("Generate data", viewModel.GenerateData));
            AddCustomButton(new DataWindowButton("Toggle error", viewModel.ToggleCustomError));

            InitializeComponent();
        }
        #endregion
    }
}