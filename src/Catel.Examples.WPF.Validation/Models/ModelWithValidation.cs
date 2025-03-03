namespace Catel.Examples.Validation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Data;

    [Serializable]
    public class ModelWithValidation : ValidatableModelBase
    {
        #region Constructors
        public ModelWithValidation()
        {
        }

        protected ModelWithValidation(SerializationInfo info, StreamingContext context)
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
            if (string.IsNullOrEmpty(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(FirstName), "First name cannot be empty"));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(LastName), "Last name cannot be empty"));
            }
        }
        #endregion
    }
}