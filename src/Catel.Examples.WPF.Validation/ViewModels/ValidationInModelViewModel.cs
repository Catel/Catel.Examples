namespace Catel.Examples.Validation.ViewModels
{
    using Models;
    using MVVM;

    public class ValidationInModelViewModel : ViewModelBase
    {
        public ValidationInModelViewModel(ModelWithValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person is null)
            {
                person = new ModelWithValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation in model";
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
