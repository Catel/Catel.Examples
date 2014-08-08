namespace Catel.Examples.SL.PersonApplication.ViewModels
{
    using System.Collections.ObjectModel;
    using Catel.Data;
    using Models;
    using MVVM;
    using Services;

    /// <summary>
    /// MainPage view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;

            Add = new Command(OnAddExecute);
            Edit = new Command(OnEditExecute, OnEditCanExecute);
            Remove = new Command(OnRemoveExecute, OnRemoveCanExecute);

            // Create default collection of persons
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
            get { return Properties.Resources.MainPageTitle; }
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
        private void OnAddExecute()
        {
            // Create view model for new person
            var viewModel = new PersonViewModel(new Person());

            // Get UI visualizer service
            _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
            {
                if (e.Result ?? false)
                {
                    PersonCollection.Add(viewModel.Person);
                }
            });
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
        private void OnEditExecute()
        {
            // Create view model for existing person
            var viewModel = new PersonViewModel(SelectedPerson);

            // Get UI visualizer service
            _uiVisualizerService.ShowDialog(viewModel);
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
        private void OnRemoveExecute()
        {
            // Remove person
            PersonCollection.Remove(SelectedPerson);
        }
        #endregion

        #region Methods
        #endregion
    }
}
