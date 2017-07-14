namespace Catel.Examples.AdvancedDemo.ViewModels
{
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// Parent view model.
    /// </summary>
    public class RoomViewModel : ViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomViewModel"/> class.
        /// </summary>
        /// <param name="room">The room.</param>
        public RoomViewModel(RoomModel room)
        {
            Argument.IsNotNull("room", room);

            Room = room;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return Name; } }

        #region Models
        /// <summary>
        /// Gets the room.
        /// </summary>
        [Model]
        public RoomModel Room
        {
            get { return GetValue<RoomModel>(RoomProperty); }
            private set { SetValue(RoomProperty, value); }
        }

        /// <summary>
        /// Register the Room property so it is known in the class.
        /// </summary>
        public static readonly PropertyData RoomProperty = RegisterProperty("Room", typeof(RoomModel));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ViewModelToModel("Room")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));
        #endregion
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}
