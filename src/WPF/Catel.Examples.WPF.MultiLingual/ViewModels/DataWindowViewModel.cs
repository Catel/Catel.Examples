// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataWindowViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MultiLingual.ViewModels
{
    using Models;
    using MVVM;

    public class DataWindowViewModel : ViewModelBase
    {
        #region Constructors
        public DataWindowViewModel(Language language)
        {
            Argument.IsNotNull("language", language);

            Language = language;

            Title = "MultiLingual example";
        }
        #endregion

        #region Properties
        [Model]
        [Fody.Expose("Name")]
        [Fody.Expose("Code")]
        private Language Language { get; set; }
        #endregion
    }
}