namespace Catel.Examples.WIN80.Advanced.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Data;

    /// <summary>
    /// HouseModel Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
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
        public HouseModel(string name, decimal price)
            : this()
        {
            Name = name;
            Price = price;
        }
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
        /// Gets or sets the price of the house.
        /// </summary>
        public decimal Price
        {
            get { return GetValue<decimal>(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        /// <summary>
        /// Register the Price property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PriceProperty = RegisterProperty("Price", typeof(decimal), 0d);

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
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "Name of house is required"));
            }
        }
        #endregion
    }
}
