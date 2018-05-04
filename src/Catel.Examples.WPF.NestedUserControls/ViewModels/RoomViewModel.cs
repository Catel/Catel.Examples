// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.ViewModels
{
    using Fody;
    using Models;
    using MVVM;

    public class RoomViewModel : ViewModelBase
    {
        #region Constructors
        public RoomViewModel(RoomModel room)
        {
            Argument.IsNotNull("room", room);

            Room = room;
        }
        #endregion

        #region Properties
        public override string Title
        {
            get { return Room.Name; }
        }

        [Model]
        [Expose("Name")]
        public RoomModel Room { get; private set; }
        #endregion
    }
}