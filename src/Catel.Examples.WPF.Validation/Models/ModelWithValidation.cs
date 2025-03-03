namespace Catel.Examples.Validation.Models
{
    using System.Collections.Generic;
    using Data;

    public class ModelWithValidation : ValidatableModelBase
    {
        public ModelWithValidation()
        {
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

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
    }
}
