namespace Catel.Examples.AdvancedDemo.ViewModels
{
    using System.Threading.Tasks;
    using Data;
    using MVVM;
    using Services;
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
        protected override async Task<bool> CancelAsync()
        {
            await _messageService.ShowInformationAsync("View model canceled");

            return await base.CancelAsync();
        }

        protected override async Task<bool> SaveAsync()
        {
            await _messageService.ShowInformationAsync("View model saved");

            return await base.SaveAsync();
        }

        protected override async Task CloseAsync()
        {
            await _messageService.ShowInformationAsync("View model closed");

            await base.CloseAsync();
        }
        #endregion
    }
}
