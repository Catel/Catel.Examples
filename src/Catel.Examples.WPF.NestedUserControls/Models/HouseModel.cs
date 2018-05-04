// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HouseModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Data;

    [Serializable]
    public class HouseModel : ValidatableModelBase
    {
        #region Constructors
        public HouseModel()
        {
            Rooms = new ObservableCollection<RoomModel>();
        }

        public HouseModel(string name, decimal price)
            : this()
        {
            Name = name;
            Price = price;
        }

        public HouseModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion

        #region Properties
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ObservableCollection<RoomModel> Rooms { get; set; }
        #endregion

        #region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Name), "Name of house is required"));
            }
        }
        #endregion
    }
}