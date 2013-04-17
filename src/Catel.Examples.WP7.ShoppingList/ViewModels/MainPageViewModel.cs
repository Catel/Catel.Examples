using System.Collections.Generic;
using System.Collections.ObjectModel;
using Catel.Data;
using Catel.Examples.WP7.ShoppingList.Data;
using Catel.MVVM;
using Catel.MVVM.Services;

namespace Catel.Examples.WP7.ShoppingList.ViewModels
{
    /// <summary>
    /// MainPage view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
            : base(false)
        {
            // This isn't really MVVM (normally, you would inject the data, but for the sake
            // of simplicity of this example, I will use a singleton)
            UserData = UserData.Instance;

            ManageShops = new Command<object>(OnManageShopsExecute);
            ManageShoppingLists = new Command<object>(OnManageShoppingListsExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Shopping cart"; } }

        #region Models
        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        [Model]
        protected UserData UserData
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
        /// Gets or sets the list of shopping lists.
        /// </summary>
        [ViewModelToModel("UserData")]
        public ObservableCollection<IShoppingList> ShoppingLists
        {
            get { return GetValue<ObservableCollection<IShoppingList>>(ShoppingListsProperty); }
            set { SetValue(ShoppingListsProperty, value); }
        }

        /// <summary>
        /// Register the ShoppingLists property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListsProperty = RegisterProperty("ShoppingLists", typeof(ObservableCollection<IShoppingList>));

        /// <summary>
        /// Gets or sets the selected shopping list.
        /// </summary>
        public IShoppingList SelectedShoppingList
        {
            get { return GetValue<IShoppingList>(SelectedShoppingListProperty); }
            set { SetValue(SelectedShoppingListProperty, value); }
        }

        /// <summary>
        /// Register the SelectedShoppingList property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShoppingListProperty = RegisterProperty("SelectedShoppingList", typeof(IShoppingList),
            null, (sender, e) => ((MainPageViewModel)sender).OnSelectedShoppingListChanged());
        #endregion
        #endregion

        #region Commands
        /// <summary>
        /// Gets the ManageShops command.
        /// </summary>
        public Command<object> ManageShops { get; private set; }

        /// <summary>
        /// Method to invoke when the ManageShops command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnManageShopsExecute(object parameter)
        {
            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ManageShopsViewModel>();
            //navigationService.Navigate("/UI/Pages/ManageShopsPage.xaml");
        }

        /// <summary>
        /// Gets the ManageShoppingLists command.
        /// </summary>
        public Command<object> ManageShoppingLists { get; private set; }

        /// <summary>
        /// Method to invoke when the ManageShoppingLists command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnManageShoppingListsExecute(object parameter)
        {
            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ManageShoppingListsViewModel>();
            //navigationService.Navigate("/UI/Pages/ManageShoppingListsPage.xaml");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the navigation has completed.
        /// </summary>
        /// <remarks></remarks>
        protected override void OnNavigationCompleted()
        {
            SelectedShoppingList = null;
        }

        /// <summary>
        /// Called when the selected shopping list has changed.
        /// </summary>
        private void OnSelectedShoppingListChanged()
        {
            if (SelectedShoppingList != null)
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("ShoppingListIndex", ShoppingLists.IndexOf(SelectedShoppingList));

                var navigationService = GetService<INavigationService>();
                navigationService.Navigate<ShoppingListViewModel>(parameters);
                //navigationService.Navigate("/UI/Pages/ShoppingListPage.xaml", parameters);
            }
        }
        #endregion
    }
}
