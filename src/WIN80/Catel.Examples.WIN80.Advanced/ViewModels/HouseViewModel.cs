namespace Catel.Examples.WinRT.Advanced.ViewModels
{
    using System.Collections.ObjectModel;
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// Current view model.
    /// </summary>
    public class HouseViewModel : ViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseViewModel"/> class.
        /// </summary>
        /// <param name="house">The house.</param>
        public HouseViewModel(HouseModel house)
        {
            Argument.IsNotNull("house", house);

            House = house;
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
        /// Gets the house.
        /// </summary>
        [Model]
        public HouseModel House
        {
            get { return GetValue<HouseModel>(HouseProperty); }
            private set { SetValue(HouseProperty, value); }
        }

        /// <summary>
        /// Register the House property so it is known in the class.
        /// </summary>
        public static readonly PropertyData HouseProperty = RegisterProperty("House", typeof(HouseModel));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ViewModelToModel("House")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));

        /// <summary>
        /// Gets or sets the price of the house.
        /// </summary>
        [ViewModelToModel("House")]
        public decimal Price
        {
            get { return GetValue<decimal>(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        /// <summary>
        /// Register the Price property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PriceProperty = RegisterProperty("Price", typeof(decimal));

        /// <summary>
        /// Gets the list of rooms in the house.
        /// </summary>
        [ViewModelToModel("House")]
        public ObservableCollection<RoomModel> Rooms
        {
            get { return GetValue<ObservableCollection<RoomModel>>(RoomsProperty); }
            private set { SetValue(RoomsProperty, value); }
        }

        /// <summary>
        /// Register the Rooms property so it is known in the class.
        /// </summary>
        public static readonly PropertyData RoomsProperty = RegisterProperty("Rooms", typeof(ObservableCollection<RoomModel>));
        #endregion
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}
