// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonModel.cs" company="Catel development team">
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
    public class PersonModel : ValidatableModelBase
    {
        #region Constructors
        public PersonModel()
        {
        }

        public PersonModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion

        #region Properties
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        #endregion

        #region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(FirstName), "First name is required"));
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(LastName), "Last name is required"));
            }
        }
        #endregion
    }
}