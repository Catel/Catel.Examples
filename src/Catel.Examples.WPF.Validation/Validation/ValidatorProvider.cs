// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorProvider.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


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