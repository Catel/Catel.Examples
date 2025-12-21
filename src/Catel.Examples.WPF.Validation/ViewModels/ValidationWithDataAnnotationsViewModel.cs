namespace Catel.Examples.Validation.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Models;
    using MVVM;

    public class ValidationWithDataAnnotationsViewModel : FeaturedViewModelBase
    {
        public ValidationWithDataAnnotationsViewModel(ModelWithoutValidation? person, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            if (person is null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;

            Title = "Validation with data annotations";
        }

        public bool DeferValidationUntilFirstSaveCallWrapper
        {
            get => DeferValidationUntilFirstSaveCall;
            set => DeferValidationUntilFirstSaveCall = value;
        }

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
    }
}
