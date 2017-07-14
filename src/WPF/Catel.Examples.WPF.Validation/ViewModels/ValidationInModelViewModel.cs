// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationInModelViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Validation.ViewModels
{
    using Data;
    using Models;
    using MVVM;

    public class ValidationInModelViewModel : ViewModelBase
    {
        #region Constructors
        public ValidationInModelViewModel(ModelWithValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person == null)
            {
                person = new ModelWithValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation in model";
        }
        #endregion

        #region Properties
        [Model]
        public ModelWithValidation Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }
        #endregion
    }
}