namespace Catel.Examples.Validation.ViewModels
{
    using System.Collections.Generic;
    using Data;
    using Models;
    using MVVM;

    public class ValidationWithValidateMethodsViewModel : ViewModelBase
    {
        public ValidationWithValidateMethodsViewModel(ModelWithoutValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person is null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation with validate methods";
        }

        [Model]
        public ModelWithoutValidation Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
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

        protected override void ValidateBusinessRules(List<IBusinessRuleValidationResult> validationResults)
        {
            validationResults.Add(BusinessRuleValidationResult.CreateError("Error 1"));
            validationResults.Add(BusinessRuleValidationResult.CreateError("Error 2"));
            validationResults.Add(BusinessRuleValidationResult.CreateError("Error 3"));
        }
    }
}
