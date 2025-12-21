namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using Fody;
    using Models;
    using MVVM;

    public class RoomViewModel : FeaturedViewModelBase
    {
        public RoomViewModel(RoomModel room, IServiceProvider serviceProvider)
            : base(serviceProvider)
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
