namespace Catel.Examples.NestedUserControls.Models
{
    using System.Collections.Generic;
    using Data;

    public class PersonModel : ValidatableModelBase
    {
        public PersonModel()
        {
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

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
    }
}
