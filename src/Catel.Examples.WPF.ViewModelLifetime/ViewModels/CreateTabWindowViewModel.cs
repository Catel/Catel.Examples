// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateTabWindowViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.ViewModelLifetime.ViewModels
{
    using MVVM;

    public class CreateTabWindowViewModel : ViewModelBase
    {
        #region Constructors
        public CreateTabWindowViewModel()
        {
            Title = "Create new tab";
        }
        #endregion

        #region Properties
        public bool CloseWhenUnloaded { get; set; }
        #endregion
    }
}