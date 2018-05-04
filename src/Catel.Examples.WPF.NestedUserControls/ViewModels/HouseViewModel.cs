// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HouseViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.ViewModels
{
    using Fody;
    using Models;
    using MVVM;

    public class HouseViewModel : ViewModelBase
    {
        #region Constructors
        public HouseViewModel(HouseModel house)
        {
            Argument.IsNotNull("house", house);

            House = house;
        }
        #endregion

        #region Properties
        public override string Title
        {
            get { return House.Name; }
        }

        #region Models
        [Model]
        [Expose("Name")]
        [Expose("Price")]
        [Expose("Rooms")]
        public HouseModel House { get; private set; }
        #endregion
        #endregion
    }
}