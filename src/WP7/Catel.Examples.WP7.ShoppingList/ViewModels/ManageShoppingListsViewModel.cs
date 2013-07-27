using System.Collections.Generic;
using System.Collections.ObjectModel;
using Catel.Data;
using Catel.Examples.WP7.ShoppingList.Data;
using Catel.MVVM;
using Catel.MVVM.Services;

namespace Catel.Examples.WP7.ShoppingList.ViewModels
{
    /// <summary>
    /// ManageShopingLists view model.
    /// </summary>
    public class ManageShoppingListsViewModel : ViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageShoppingListsViewModel"/> class.
        /// </summary>
        public ManageShoppingListsViewModel()
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
        public override string Title { get { return "Shopping lists"; } }

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
        /// Gets or sets the list of shopping list.
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
        public static readonly PropertyData SelectedShoppingListProperty = RegisterProperty("SelectedShoppingList", typeof(IShoppingList));
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
            navigationService.Navigate<ShoppingListViewModel>();
            //navigationService.Navigate("/UI/Pages/ShoppingListPage.xaml");
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
            return (SelectedShoppingList != null);
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnEditExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShoppingListIndex", ShoppingLists.IndexOf(SelectedShoppingList));

            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ShoppingListViewModel>(parameters);
            //navigationService.Navigate("/UI/Pages/ShoppingListPage.xaml", parameters);
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
            return (SelectedShoppingList != null);
        }

        /// <summary>
        /// Method to invoke when the Delete command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnDeleteExecute(object parameter)
        {
            var messageService = GetService<IMessageService>();
            if (messageService.Show("Are you sure that you want to remove the selected shopping list?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                ShoppingLists.Remove(SelectedShoppingList);
                SelectedShoppingList = null;
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
