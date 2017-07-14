// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.PersonApplication.ViewModels
{
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
        #region Fields
        private readonly IMessageService _messageService;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => messageService);

            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            Add = new TaskCommand(OnAddExecuteAsync);
            Edit = new TaskCommand(OnEditExecuteAsync, OnEditCanExecute);
            Remove = new TaskCommand(OnRemoveExecuteAsync, OnRemoveCanExecute);

            PersonCollection = new ObservableCollection<Person>();
            PersonCollection.Add(new Person {Gender = Gender.Male, FirstName = "Geert", MiddleName = "van", LastName = "Horrik"});
            PersonCollection.Add(new Person {Gender = Gender.Male, FirstName = "Fred", MiddleName = "", LastName = "Retteket"});

            Title = Resources.MainWindowTitle;
        }
        #endregion

        #region Properties
        public ObservableCollection<Person> PersonCollection { get; private set; }

        public Person SelectedPerson { get; set; }
        #endregion

        #region Commands
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
            return (SelectedPerson != null);
        }

        private async Task OnEditExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<PersonViewModel>(SelectedPerson);
        }

        public TaskCommand Remove { get; private set; }

        private bool OnRemoveCanExecute()
        {
            return (SelectedPerson != null);
        }

        private async Task OnRemoveExecuteAsync()
        {
            if (await _messageService.ShowAsync("Are you sure you want to remove this person?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
            {
                PersonCollection.Remove(SelectedPerson);
            }
        }
        #endregion
    }
}