namespace Catel.Examples.WPF.Memento.ViewModels
{
    using System.Collections.ObjectModel;
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
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            Add = new Command(OnAddExecute);
            Edit = new Command(OnEditExecute, OnEditCanExecute);
            Remove = new Command(OnRemoveExecute, OnRemoveCanExecute);

            Undo = new Command(() => MementoService.Undo(), () => MementoService.CanUndo);
            Redo = new Command(() => MementoService.Redo(), () => MementoService.CanRedo);

            

            PersonCollection = new ObservableCollection<Person> {new Person {Gender = Gender.Male, FirstName = "Geert", MiddleName = "van", LastName = "Horrik"}, new Person {Gender = Gender.Male, FirstName = "Fred", MiddleName = "", LastName = "Retteket"}};

            MementoService.RegisterCollection(PersonCollection);
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
        /// Gets the memento service.
        /// </summary>
        private IMementoService MementoService { get { return GetService<IMementoService>(); }}

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
            var viewModel = new PersonViewModel(new Person());
            var uiVisualizerService = GetService<IUIVisualizerService>();
            if (uiVisualizerService.ShowDialog(viewModel) ?? false)
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
            var viewModel = new PersonViewModel(SelectedPerson);
            var uiVisualizerService = GetService<IUIVisualizerService>();
            uiVisualizerService.ShowDialog(viewModel);
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
            var messageService = GetService<IMessageService>();
            if (messageService.Show("Are you sure you want to remove this person?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
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
            MementoService.UnregisterCollection(PersonCollection);

            base.OnClosed(result);
        }
        #endregion
    }
}
