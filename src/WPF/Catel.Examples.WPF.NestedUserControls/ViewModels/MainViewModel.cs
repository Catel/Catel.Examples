// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System.Collections.ObjectModel;
    using Models;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        #region Constructors
        public MainViewModel()
        {
            Houses = new ObservableCollection<HouseModel>(ModelGenerator.GenerateHouses());

            Title = "Nested User Controls Example";
        }
        #endregion

        #region Properties
        public ObservableCollection<HouseModel> Houses { get; private set; }
        #endregion
    }
}