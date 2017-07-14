// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationWithDataAnnotationsViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Validation.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Models;
    using MVVM;

    public class ValidationWithDataAnnotationsViewModel : ViewModelBase
    {
        #region Constructors
        public ValidationWithDataAnnotationsViewModel(ModelWithoutValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person == null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation with data annotations";
        }
        #endregion

        #region Properties
        [Model]
        public ModelWithoutValidation Person { get; private set; }

        [Required(ErrorMessage = "First name cannot be empty")]
        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Last name cannot be empty")]
        [ViewModelToModel("Person")]
        public string LastName { get; set; }
        #endregion
    }
}