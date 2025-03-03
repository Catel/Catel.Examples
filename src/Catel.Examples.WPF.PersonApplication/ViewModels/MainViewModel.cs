namespace Catel.Examples.PersonApplication.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using MVVM;
    using Properties;
    using Services;
    using IMessageService = Services.IMessageService;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);
            ArgumentNullException.ThrowIfNull(messageService);

            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            Add = new TaskCommand(OnAddExecuteAsync);
            Edit = new TaskCommand(OnEditExecuteAsync, OnEditCanExecute);
            Remove = new TaskCommand(OnRemoveExecuteAsync, OnRemoveCanExecute);

            PersonCollection = new ObservableCollection<Person>();
            PersonCollection.Add(new Person {Gender = Gender.Male, FirstName = "Geert", MiddleName = "van", LastName = "Horrik"});
            PersonCollection.Add(new Person {Gender = Gender.Male, FirstName = "Fred", MiddleName = string.Empty, LastName = "Retteket"});

            Title = Resources.MainWindowTitle;
        }

        public ObservableCollection<Person> PersonCollection { get; private set; }

        public Person SelectedPerson { get; set; }

        public TaskCommand Add { get; private set; }

        private async Task OnAddExecuteAsync()
        {
            var person = new Person();

            if (await _uiVisualizerService.ShowDialogAsync<PersonViewModel>(person) ?? false)
            {
                PersonCollection.Add(person);
            }
        }

        public TaskCommand Edit { get; private set; }

        private bool OnEditCanExecute()
        {
            return (SelectedPerson is not null);
        }

        private async Task OnEditExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<PersonViewModel>(SelectedPerson);
        }

        public TaskCommand Remove { get; private set; }

        private bool OnRemoveCanExecute()
        {
            return (SelectedPerson is not null);
        }

        private async Task OnRemoveExecuteAsync()
        {
            if (await _messageService.ShowAsync("Are you sure you want to remove this person?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
            {
                PersonCollection.Remove(SelectedPerson);
            }
        }
    }
}
