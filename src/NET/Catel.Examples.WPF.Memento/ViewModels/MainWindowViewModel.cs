namespace Catel.Examples.WPF.Memento.ViewModels
{
    using System.Collections.ObjectModel;
    using Catel.IoC;
    using MVVM;
    using Catel.Memento;
    using Data;
    using MVVM.Services;
    using Models;
    using Properties;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;
        private readonly IMementoService _mementoService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService, IMementoService mementoService)
        {
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;
            _mementoService = mementoService;

            Add = new Command(OnAddExecute);
            Edit = new Command(OnEditExecute, OnEditCanExecute);
            Remove = new Command(OnRemoveExecute, OnRemoveCanExecute);

            Undo = new Command(() => _mementoService.Undo(), () => _mementoService.CanUndo);
            Redo = new Command(() => _mementoService.Redo(), () => _mementoService.CanRedo);

            PersonCollection = new ObservableCollection<Person> {new Person {Gender = Gender.Male, FirstName = "Geert", MiddleName = "van", LastName = "Horrik"}, new Person {Gender = Gender.Male, FirstName = "Fred", MiddleName = "", LastName = "Retteket"}};

            _mementoService.RegisterCollection(PersonCollection);
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
        private void OnAddExecute()
        {
            var typeFactory = TypeFactory.Default;
            var viewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<PersonViewModel>(new Person());
            if (_uiVisualizerService.ShowDialog(viewModel) ?? false)
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
        private void OnEditExecute()
        {
            var typeFactory = TypeFactory.Default;
            var viewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<PersonViewModel>(SelectedPerson);
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
            if (_messageService.Show("Are you sure you want to remove this person?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
            {
                PersonCollection.Remove(SelectedPerson);
            }
        }

        /// <summary>
        /// Gets the undo.
        /// </summary>
        public Command Undo { get; private set; }

        /// <summary>
        /// Gets the redo.
        /// </summary>
        public Command Redo { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the view model has just been closed.
        /// <para/>
        /// This method also raises the <see cref="E:Catel.MVVM.ViewModelBase.Closed"/> event.
        /// </summary>
        /// <param name="result">The result to pass to the view. This will, for example, be used as <c>DialogResult</c>.</param>
        protected override void OnClosed(bool? result)
        {
            _mementoService.UnregisterCollection(PersonCollection);

            base.OnClosed(result);
        }
        #endregion
    }
}
