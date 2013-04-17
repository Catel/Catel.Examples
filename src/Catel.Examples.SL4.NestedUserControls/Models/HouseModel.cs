namespace Catel.Examples.SL4.NestedUserControls.Models
{
    using System.Collections.ObjectModel;
    using Data;

    /// <summary>
    /// HouseModel Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
[Serializable]
#endif
    public class HouseModel : ModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseModel"/> class.
        /// </summary>
        public HouseModel()
        {
            Rooms = new ObservableCollection<RoomModel>();
        }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        /// <param name="name">The name.</param>
        public HouseModel(string name)
            : this()
        {
            Name = name;
        }

#if !SILVERLIGHT	
    /// <summary>
    /// Initializes a new object based on <see cref="SerializationInfo"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected HouseModel(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
#endif
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), string.Empty);

        /// <summary>
        /// Gets the list of rooms in the house.
        /// </summary>
        public ObservableCollection<RoomModel> Rooms
        {
            get { return GetValue<ObservableCollection<RoomModel>>(RoomsProperty); }
            set { SetValue(RoomsProperty, value); }
        }

        /// <summary>
        /// Register the Rooms property so it is known in the class.
        /// </summary>
        public static readonly PropertyData RoomsProperty = RegisterProperty("Rooms", typeof(ObservableCollection<RoomModel>));
        #endregion

        #region Methods
        #endregion
    }
}
