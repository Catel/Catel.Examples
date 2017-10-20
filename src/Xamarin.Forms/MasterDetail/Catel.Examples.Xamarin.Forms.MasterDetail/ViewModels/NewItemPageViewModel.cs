namespace Catel.Examples.Xamarin.Forms.MasterDetail.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Models;
    using Catel.Examples.Xamarin.Forms.MasterDetail.Services.Interfaces;
    using Catel.MVVM;
    using Catel.Services;

    public class NewItemPageViewModel : ViewModelBase
    {
        private readonly IDataStore<Item> _dataStore;

        private readonly INavigationService _navigationService;

        public NewItemPageViewModel(IDataStore<Item> dataStore, INavigationService navigationService)
        {
            Argument.IsNotNull(() => dataStore);
            Argument.IsNotNull(() => navigationService);

            _dataStore = dataStore;
            _navigationService = navigationService;

            SaveCommand = new TaskCommand(OnSaveCommandExecute);

            Item = new Item
            {
                Text = "Item name",
                Description = "This is a nice description"
            };
        }

        private async Task OnSaveCommandExecute()
        {
            await _dataStore.AddItemAsync(Item);

            _navigationService.GoBack();
        }

        public ICommand SaveCommand { get; }

        [Model]
        public Item Item { get; set; }


        [ViewModelToModel("Item")]
        public string Text { get; set; }

        [ViewModelToModel("Item")]
        public string Description { get; set; }
    }
}