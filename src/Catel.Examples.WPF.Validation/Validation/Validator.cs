namespace Catel.Examples.WPF.Validation.Validation
{
    using System.Collections.Generic;
    using Data;
    using ViewModels;

    /// <summary>
    /// Default validator for this example application.
    /// </summary>
    public class Validator : ValidatorBase<ValidationInIValidatorViewModel>
    {
        /// <summary>
        /// Validates the fields of the specified instance. The results must be added to the list of validation
        /// results.
        /// </summary>
        /// <param name="instance">The instance to validate.</param>
        /// <param name="validationResults">The validation results.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="instance"/> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="validationResults"/> is <c>null</c>.</exception>
        public override void ValidateFields(ValidationInIValidatorViewModel instance, List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(instance.FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(ValidationInIValidatorViewModel.FirstNameProperty, "First name cannot be empty"));
            }

            if (string.IsNullOrEmpty(instance.LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(ValidationInIValidatorViewModel.LastNameProperty, "Last name cannot be empty"));
            }
        }

        /// <summary>
        /// Validates the business rules of the specified instance. The results must be added to the list of validation
        /// results.
        /// </summary>
        /// <param name="instance">The instance to validate.</param>
        /// <param name="validationResults">The validation results.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="instance"/> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="validationResults"/> is <c>null</c>.</exception>
        public override void ValidateBusinessRules(ValidationInIValidatorViewModel instance, List<IBusinessRuleValidationResult> validationResults)
        {
            // No business rules (yet)
        }
    }
}
