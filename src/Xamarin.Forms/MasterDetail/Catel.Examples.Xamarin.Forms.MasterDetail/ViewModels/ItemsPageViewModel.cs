namespace Catel.Examples.Xamarin.Forms.MasterDetail.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Catel.Collections;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Models;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Services.Interfaces;
    using Catel.MVVM;
    using Catel.Services;

    public class ItemsPageViewModel : ViewModelBase
    {
        private readonly IDataStore<Item> _dataStore;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public ItemsPageViewModel(IDataStore<Item> dataStore, INavigationService navigationService,
            IMessageService messageService)
        {
            Argument.IsNotNull(()=> dataStore);
            Argument.IsNotNull(()=> navigationService);
            Argument.IsNotNull(()=> messageService);

            _dataStore = dataStore;
            _navigationService = navigationService;
            _messageService = messageService;

            LoadItemsCommand = new TaskCommand(OnLoadItemsCommandExecute);
            AddItemCommand = new TaskCommand(OnAddItemCommandExecute);
        }

        public override string Title => "Browse";

        public FastObservableCollection<Item> Items { get; } = new FastObservableCollection<Item>();

        public Item SelectedItem { get; set; }

        public ICommand LoadItemsCommand { get; }

        public ICommand AddItemCommand { get; }

        public bool IsBusy { get; set; }

        private async Task OnAddItemCommandExecute()
        {
            _navigationService.Navigate<NewItemPageViewModel>();
        }

        private void OnSelectedItemChanged()
        {
            if (SelectedItem != null)
            {
                _navigationService.Navigate<ItemDetailPageViewModel>(SelectedItem);
                SelectedItem = null;
            }
        }

        protected override async Task InitializeAsync()
        {
            await Task.Run(LoadItems);
        }

        private async Task OnLoadItemsCommandExecute()
        {
            await LoadItems();
        }

        private async Task LoadItems()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception)
            {
                await _messageService.ShowErrorAsync("Unable to load items", "Error");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}