namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using Fody;
    using Models;
    using MVVM;

    public class RoomViewModel : ViewModelBase
    {
        public RoomViewModel(RoomModel room)
        {
            ArgumentNullException.ThrowIfNull(room);

            Room = room;
        }

        public override string Title
        {
            get { return Room.Name; }
        }

        [Model]
        [Expose("Name")]
        public RoomModel Room { get; private set; }
    }
}
