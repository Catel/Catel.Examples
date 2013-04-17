namespace Catel.Examples.SL4.PersonApplication.ViewModels
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
            // Store values or create new if null is passed
            Person = person ?? new Person();
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

        public static string StaticValue { get { return "Hello"; } }

		#region Models
		/// <summary>
		/// Gets or sets the person model.
		/// </summary>
        [Model]
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

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [ViewModelToModel("Person")]
        public string FirstName
        {
	        get { return GetValue<string>(FirstNameProperty); }
	        set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string));

		/// <summary>
		/// Gets or sets the middle name.
		/// </summary>
		[ViewModelToModel("Person")]
		public string MiddleName
		{
			get { return GetValue<string>(MiddleNameProperty); }
			set { SetValue(MiddleNameProperty, value); }
		}

		/// <summary>
		/// Register the MiddleName property so it is known in the class.
		/// </summary>
		public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof(string));

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		[ViewModelToModel("Person")]
		public string LastName
		{
			get { return GetValue<string>(LastNameProperty); }
			set { SetValue(LastNameProperty, value); }
		}

		/// <summary>
		/// Register the LastName property so it is known in the class.
		/// </summary>
		public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string));
		#endregion
		#endregion

		#region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                if (validationResult.PropertyName == Person.FirstNameProperty.Name)
                {
                    validationResult.Message = "First name is required, text customized in view model";
                }
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
            : base(new Person { FirstName = "Geert", MiddleName = "van", LastName = "Horrik", Gender = Gender.Male })
        {
        }
    }
}