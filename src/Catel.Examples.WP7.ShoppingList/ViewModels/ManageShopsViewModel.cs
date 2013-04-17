using System.Collections.Generic;
using System.Collections.ObjectModel;
using Catel.Data;
using Catel.Examples.WP7.ShoppingList.Data;
using Catel.MVVM;
using Catel.MVVM.Services;

namespace Catel.Examples.WP7.ShoppingList.ViewModels
{
    /// <summary>
    /// ManageShops view model.
    /// </summary>
    public class ManageShopsViewModel : ViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageShopsViewModel"/> class.
        /// </summary>
        public ManageShopsViewModel()
            : base(false)
        {
            // This isn't really MVVM (normally, you would inject the data, but for the sake
            // of simplicity of this example, I will use a singleton)
            UserData = UserData.Instance;

            Home = new Command<object>(OnHomeExecute);
            Add = new Command<object>(OnAddExecute);
            Edit = new Command<object, object>(OnEditExecute, OnEditCanExecute);
            Delete = new Command<object, object>(OnDeleteExecute, OnDeleteCanExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Shops"; } }

        #region Models
        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        [Model]
        private UserData UserData
        {
            get { return GetValue<UserData>(UserDataProperty); }
            set { SetValue(UserDataProperty, value); }
        }

        /// <summary>
        /// Register the UserData property so it is known in the class.
        /// </summary>
        public static readonly PropertyData UserDataProperty = RegisterProperty("UserData", typeof(UserData));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the list of shops.
        /// </summary>
        [ViewModelToModel("UserData")]
        public ObservableCollection<IShop> Shops
        {
            get { return GetValue<ObservableCollection<IShop>>(ShopsProperty); }
            set { SetValue(ShopsProperty, value); }
        }

        /// <summary>
        /// Register the Shops property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShopsProperty = RegisterProperty("Shops", typeof(ObservableCollection<IShop>));

        /// <summary>
        /// Gets or sets the selected shop.
        /// </summary>
        public IShop SelectedShop
        {
            get { return GetValue<IShop>(SelectedShopProperty); }
            set { SetValue(SelectedShopProperty, value); }
        }

        /// <summary>
        /// Register the SelectedShop property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShopProperty = RegisterProperty("SelectedShop", typeof(IShop));
        #endregion
        #endregion

        #region Commands
        /// <summary>
        /// Gets the Home command.
        /// </summary>
        public Command<object> Home { get; private set; }

        /// <summary>
        /// Method to invoke when the Home command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnHomeExecute(object parameter)
        {
            SaveViewModel();

            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<MainPageViewModel>();
            //navigationService.Navigate("/UI/Pages/MainPage.xaml");
        }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public Command<object> Add { get; private set; }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnAddExecute(object parameter)
        {
            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ShopViewModel>();
            //navigationService.Navigate("/UI/Pages/ShopPage.xaml");
        }

        /// <summary>
        /// Gets the Edit command.
        /// </summary>
        public Command<object, object> Edit { get; private set; }

        /// <summary>
        /// Method to check whether the Edit command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnEditCanExecute(object parameter)
        {
            return (SelectedShop != null);
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnEditExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShopIndex", Shops.IndexOf(SelectedShop));

            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ShopViewModel>(parameters);
            //navigationService.Navigate("/UI/Pages/ShopPage.xaml", parameters);
        }

        /// <summary>
        /// Gets the Delete command.
        /// </summary>
        public Command<object, object> Delete { get; private set; }

        /// <summary>
        /// Method to check whether the Delete command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnDeleteCanExecute(object parameter)
        {
            return (SelectedShop != null);
        }

        /// <summary>
        /// Method to invoke when the Delete command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnDeleteExecute(object parameter)
        {
            var messageService = GetService<IMessageService>();
            if (messageService.Show("Are you sure that you want to remove the selected shop?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                Shops.Remove(SelectedShop);
                SelectedShop = null;
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
