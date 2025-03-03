namespace Catel.Examples.Validation.Validation
{
    using System;
    using Data;
    using ViewModels;

    public class ValidatorProvider : ValidatorProviderBase
    {
        #region Methods
        protected override IValidator GetValidator(Type targetType)
        {
            if (targetType == typeof(ValidationInIValidatorViewModel))
            {
                return new Validator();
            }

            return null;
        }
        #endregion
    }
}