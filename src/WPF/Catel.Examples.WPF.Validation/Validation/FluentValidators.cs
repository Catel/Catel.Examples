// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentValidators.cs" company="Catel development team">
//   Copyright (c) 2008 - 2012 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.Validation.Validation
{
    using Data;
    using FluentValidation;
    using ViewModels;

    /// <summary>
    /// The fluent validator.
    /// </summary>
    [ValidatorDescription("Person")]
    public class FluentFieldErrorValidator : AbstractValidator<ValidationWithFluentValidationViewModel>
    {
        public FluentFieldErrorValidator()
        {
            RuleFor(model => model.FirstName).NotNull().NotEmpty();
            RuleFor(model => model.MiddleName).NotNull().NotEmpty();
            RuleFor(model => model.LastName).NotNull().NotEmpty().WithMessage("Last name cannot be empty");
        }
    }

    [ValidatorDescription("Person", ValidationResultType.Warning, ValidationType.BusinessRule)]
    public class FluentBusinessRuleWarningValidator : AbstractValidator<ValidationWithFluentValidationViewModel>
    {
        public FluentBusinessRuleWarningValidator()
        {
            RuleFor(model => model.FirstName).Length(4, 10);
            RuleFor(model => model.LastName).Length(4, 10);
            RuleFor(model => model.MiddleName).Length(4, 10);
        }
    }
}