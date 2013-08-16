namespace Catel.Examples.AdvancedDemo.ViewModels
{
    using Data;
    using MVVM;
    using MVVM.Services;
    using Models;

    /// <summary>
    /// Window view model.
    /// </summary>
    public class DemoWindowViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoWindowViewModel"/> class.
        /// </summary>
        public DemoWindowViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            Person = new PersonModel();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Person demo window"; } }

        #region Models
        /// <summary>
        /// Gets the person.
        /// </summary>
        [Model]
        public PersonModel Person
        {
            get { return GetValue<PersonModel>(PersonProperty); }
            private set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Register the Person property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(PersonModel));
        #endregion

        #region View model
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

        #region Commands
        #endregion

        #region Methods
        protected override bool Cancel()
        {
            _messageService.ShowInformation("View model canceled");

            return base.Cancel();
        }

        protected override bool Save()
        {
            _messageService.ShowInformation("View model saved");

            return base.Save();
        }

        protected override void Close()
        {
            _messageService.ShowInformation("View model closed");

            base.Close();
        }
        #endregion
    }
}
