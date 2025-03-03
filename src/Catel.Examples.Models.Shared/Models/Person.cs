namespace Catel.Examples.Models
{
    using System.Collections.Generic;
    using Data;

    public class Person : ValidatableModelBase
    {
        public Person()
        {
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(FirstName), "First name is required"));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(LastName), "Last name is required"));
            }

            if (Gender == Gender.Unknown)
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Gender), "Gender cannot be unknown"));
            }
        }
    }
}
