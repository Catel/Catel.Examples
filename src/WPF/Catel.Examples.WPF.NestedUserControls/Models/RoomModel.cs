// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Data;

    [Serializable]
    public class RoomModel : ValidatableModelBase
    {
        #region Constructors
        public RoomModel()
        {
        }

        public RoomModel(string name)
            : this()
        {
            Name = name;
        }

        public RoomModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Name), "Name of room is required"));
            }
        }
        #endregion
    }
}