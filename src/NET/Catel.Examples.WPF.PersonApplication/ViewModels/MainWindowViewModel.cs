namespace Catel.Examples.WPF.PersonApplication.ViewModels
{
    using System.Collections.ObjectModel;
    using Catel.Data;
    using Models;
    using Properties;
    using MVVM;
    using Services;

    /// <summary>
    /// Main window view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            Add = new Command(OnAddExecute);
            Edit = new Command(OnEditExecute, OnEditCanExecute);
            Remove = new Command(OnRemoveExecute, OnRemoveCanExecute);

            PersonCollection = new ObservableCollection<Person>();
            PersonCollection.Add(new Person { Gender = Gender.Male, FirstName = "Geert", MiddleName = "van", LastName = "Horrik" });
            PersonCollection.Add(new Person { Gender = Gender.Male, FirstName = "Fred", MiddleName = "", LastName = "Retteket" });
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return Resources.MainWindowTitle; }
        }

        /// <summary>
        /// Gets the collection of Persons.
        /// </summary>
        public ObservableCollection<Person> PersonCollection
        {
            get { return GetValue<ObservableCollection<Person>>(PersonCollectionProperty); }
            set { SetValue(PersonCollectionProperty, value); }
        }

        /// <summary>
        /// Register the PersonCollection property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PersonCollectionProperty = RegisterProperty("PersonCollection", typeof(ObservableCollection<Person>));

        /// <summary>
        /// Gets or sets the selected person.
        /// </summary>
        public Person SelectedPerson
        {
            get { return GetValue<Person>(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        /// <summary>
        /// Register the SelectedPerson property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedPersonProperty = RegisterProperty("SelectedPerson", typeof(Person), null);
        #endregion

        #region Commands
        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public Command Add { get; private set; }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        private async void OnAddExecute()
        {
            var viewModel = new PersonViewModel(new Person());
            if (await _uiVisualizerService.ShowDialog(viewModel) ?? false)
            {
                PersonCollection.Add(viewModel.Person);
            }
        }

        /// <summary>
        /// Gets the Edit command.
        /// </summary>
        public Command Edit { get; private set; }

        /// <summary>
        /// Method to check whether the Edit command can be executed.
        /// </summary>
        /// <returns></returns>
        private bool OnEditCanExecute()
        {
            return (SelectedPerson != null);
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        private async void OnEditExecute()
        {
            var viewModel = new PersonViewModel(SelectedPerson);
            await _uiVisualizerService.ShowDialog(viewModel);
        }

        /// <summary>
        /// Gets the Remove command.
        /// </summary>
        public Command Remove { get; private set; }

        /// <summary>
        /// Method to check whether the Remove command can be executed.
        /// </summary>
        /// <returns></returns>
        private bool OnRemoveCanExecute()
        {
            return (SelectedPerson != null);
        }

        /// <summary>
        /// Method to invoke when the Remove command is executed.
        /// </summary>
        private async void OnRemoveExecute()
        {
            if (await _messageService.Show("Are you sure you want to remove this person?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
            {
                PersonCollection.Remove(SelectedPerson);
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
