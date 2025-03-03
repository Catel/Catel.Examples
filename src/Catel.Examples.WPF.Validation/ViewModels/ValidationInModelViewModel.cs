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
            if (person is null)
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