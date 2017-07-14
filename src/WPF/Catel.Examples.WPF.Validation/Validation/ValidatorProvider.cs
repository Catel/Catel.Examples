namespace Catel.Examples.WPF.Validation.Validation
{
    using System;
    using Data;
    using ViewModels;

    /// <summary>
    /// Main validator provider.
    /// </summary>
    public class ValidatorProvider : ValidatorProviderBase
    {
        /// <summary>
        /// Provides an access point to allow a custom implementation in order to retrieve the available validator for the specified type.
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <returns>The <see cref="T:Catel.Data.IValidator"/> for the specified type or <c>null</c> if no validator is available for the specified type.</returns>
        /// <remarks></remarks>
        protected override IValidator GetValidator(Type targetType)
        {
            if (targetType == typeof(ValidationInIValidatorViewModel))
            {
                return new Validator();
            }

            return null;
        }
    }
}
