// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationInIValidatorViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Validation.ViewModels
{
    using Data;
    using Models;
    using MVVM;

    public class ValidationInIValidatorViewModel : ViewModelBase
    {
        #region Constructors
        public ValidationInIValidatorViewModel(ModelWithoutValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person == null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation in IValidator";
        }
        #endregion

        #region Properties
        [Model]
        public ModelWithoutValidation Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }
        #endregion
    }
}