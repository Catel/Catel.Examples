namespace Catel.Examples.Validation.ViewModels
{
    using System;
    using Models;
    using MVVM;

    public class ValidationInModelViewModel : FeaturedViewModelBase
    {
        public ValidationInModelViewModel(ModelWithValidation? person, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            if (person is null)
            {
                person = new ModelWithValidation();
            }

            Person = person;

            Title = "Validation in model";
        }

        public bool DeferValidationUntilFirstSaveCallWrapper
        {
            get => DeferValidationUntilFirstSaveCall;
            set => DeferValidationUntilFirstSaveCall = value;
        }

        [Model]
        public ModelWithValidation Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }
    }
}
