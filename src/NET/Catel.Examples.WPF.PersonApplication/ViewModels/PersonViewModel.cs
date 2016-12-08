namespace Catel.Examples.WPF.PersonApplication.ViewModels
{
    using System.Collections.Generic;
    using Catel.Data;
    using Models;
    using MVVM;

    /// <summary>
    /// Person view model.
    /// </summary>
    public class PersonViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        /// <param name="person">The person.</param>
        public PersonViewModel(Person person)
        {
            if (Catel.CatelEnvironment.IsInDesignMode)
                return; // This prevents constructor code from being executed at design-time
            Person = person ?? new Person();
            GenerateData = new Command<object, object>(OnGenerateDataExecute, OnGenerateDataCanExecute);
            ToggleCustomError = new Command<object>(OnToggleCustomErrorExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Person"; }
        }

        #region Models
        /// <summary>
        /// Gets or sets the person model.
        /// </summary>
        [Model]
        [Fody.Expose("FirstName")]
        [Fody.Expose("MiddleName")]
        [Fody.Expose("LastName")]
        public Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            private set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(Person));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        [ViewModelToModel("Person")]
        public Gender Gender
        {
            get { return GetValue<Gender>(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        /// <summary>
        /// Register the Gender property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GenderProperty = RegisterProperty("Gender", typeof(Gender));

        ///// <summary>
        ///// Gets or sets the first name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string FirstName
        //{
        //    get { return GetValue<string>(FirstNameProperty); }
        //    set { SetValue(FirstNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the FirstName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string));

        ///// <summary>
        ///// Gets or sets the middle name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string MiddleName
        //{
        //    get { return GetValue<string>(MiddleNameProperty); }
        //    set { SetValue(MiddleNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the MiddleName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof(string));

        ///// <summary>
        ///// Gets or sets the last name.
        ///// </summary>
        //[ViewModelToModel("Person")]
        //public string LastName
        //{
        //    get { return GetValue<string>(LastNameProperty); }
        //    set { SetValue(LastNameProperty, value); }
        //}

        ///// <summary>
        ///// Register the LastName property so it is known in the class.
        ///// </summary>
        //public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string));

        /// <summary>
        /// Gets or sets the custom error.
        /// </summary>
        public string CustomError
        {
            get { return GetValue<string>(CustomErrorProperty); }
            set { SetValue(CustomErrorProperty, value); }
        }

        /// <summary>
        /// Register the CustomError property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CustomErrorProperty = RegisterProperty("CustomError", typeof(string));

        /// <summary>
        /// Gets the custom defined property to test whether the ICustomTypeDescriptor for WPF works.
        /// </summary>
        public string CustomDefinedProperty { get { return "My Custom Defined Property"; } }
        #endregion

        #region Commands

        /// <summary>
        /// Gets the GenerateData command.
        /// </summary>
        public Command<object, object> GenerateData { get; private set; }

        /// <summary>
        /// Method to check whether the GenerateData command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnGenerateDataCanExecute(object parameter)
        {
            // Note: normally you wouldn't use the ExposeAttribute if you need to access
            // the properties, but this is to show that all existing features (such as
            // INotifyPropertyChanged, IDataErrorInfo, etc also work with the ExposeAttribute).

            if (!string.IsNullOrEmpty(GetValue<string>("FirstName")))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(GetValue<string>("MiddleName")))
            {
                return false;
            }

            if (!string.IsNullOrEmpty(GetValue<string>("LastName")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method to invoke when the GenerateData command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnGenerateDataExecute(object parameter)
        {
            Gender = Gender.Male;
            SetValue("FirstName", "John");
            SetValue("MiddleName", "");
            SetValue("LastName", "Doe");
        }

        /// <summary>
        /// Gets the ToggleCustomError command.
        /// </summary>
        public Command<object> ToggleCustomError { get; private set; }

        /// <summary>
        /// Method to invoke when the ToggleCustomError command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnToggleCustomErrorExecute(object parameter)
        {
            if (string.IsNullOrEmpty(CustomError))
            {
                CustomError = "Error message 1";
            }
            else if (CustomError == "Error message 1")
            {
                CustomError = "Replaced error message, does tooltip update?";
            }
            else
            {
                CustomError = string.Empty;
            }
        }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (!string.IsNullOrEmpty(CustomError))
            {
                validationResults.Add(FieldValidationResult.CreateError(CustomErrorProperty, CustomError));
            }
        }
        #endregion
    }

    /// <summary>
    /// Design time version of the <see cref="PersonViewModel"/>.
    /// </summary>
    public class DesignPersonViewModel : PersonViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignPersonViewModel"/> class.
        /// </summary>
        public DesignPersonViewModel()
            : base(null)
        {
            SetValue("FirstName", "Geert");
            SetValue("MiddleName", "van");
            SetValue("LastName", "Horrik");
            Gender = Gender.Male;
        }
    }
}