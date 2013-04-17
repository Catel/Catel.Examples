namespace Catel.Examples.WP7.ShoppingList.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Catel.Data;
    using Data;
    using MVVM;
    using MVVM.Services;

    /// <summary>
    /// ShoppingList view model.
    /// </summary>
    public class ShoppingListViewModel : ViewModelBase
    {
        #region Variables
        private int _shoppingListIndex = -1;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListViewModel"/> class.
        /// </summary>
        public ShoppingListViewModel()
        {
            Back = new Command<object>(OnBackExecute);
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
        public override string Title { get { return "Shopping list"; } }

        #region Models
        /// <summary>
        /// Gets the shopping list.
        /// </summary>
        [Model]
        public IShoppingList ShoppingList
        {
            get { return GetValue<IShoppingList>(ShoppingListProperty); }
            private set { SetValue(ShoppingListProperty, value); }
        }

        /// <summary>
        /// Register the ShoppingList property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListProperty = RegisterProperty("ShoppingList", typeof(IShoppingList));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the name of the shopping list.
        /// </summary>
        [ViewModelToModel("ShoppingList")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));

        /// <summary>
        /// Gets or sets the list of shopping list items.
        /// </summary>
        [ViewModelToModel("ShoppingList", "Items")]
        public ObservableCollection<IShoppingListItem> ShoppingListItems
        {
            get { return GetValue<ObservableCollection<IShoppingListItem>>(ShoppingListItemsProperty); }
            set { SetValue(ShoppingListItemsProperty, value); }
        }

        /// <summary>
        /// Register the ShoppingListItems property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListItemsProperty = RegisterProperty("ShoppingListItems", typeof(ObservableCollection<IShoppingListItem>));

        /// <summary>
        /// Gets or sets the selected shopping list item.
        /// </summary>
        public IShoppingListItem SelectedShoppingListItem
        {
            get { return GetValue<IShoppingListItem>(SelectedShoppingListItemProperty); }
            set { SetValue(SelectedShoppingListItemProperty, value); }
        }

        /// <summary>
        /// Register the SelectedShoppingListItem property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShoppingListItemProperty = RegisterProperty("SelectedShoppingListItem", typeof(IShoppingListItem));
        #endregion
        #endregion

        #region Commands
        /// <summary>
        /// Gets the Back command.
        /// </summary>
        public Command<object> Back { get; private set; }

        /// <summary>
        /// Method to invoke when the Back command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnBackExecute(object parameter)
        {
            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ManageShoppingListsViewModel>();
            //navigationService.Navigate("/UI/Pages/ManageShoppingListsPage.xaml");
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
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShoppingListIndex", _shoppingListIndex);

            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ShoppingListItemViewModel>(parameters);
            //navigationService.Navigate("/UI/Pages/ShoppingListItemPage.xaml", parameters);
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
            return SelectedShoppingListItem != null;
        }

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnEditExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShoppingListIndex", _shoppingListIndex);
            parameters.Add("ShoppingListItemIndex", ShoppingListItems.IndexOf(SelectedShoppingListItem));

            var navigationService = GetService<INavigationService>();
            navigationService.Navigate<ShoppingListItemViewModel>(parameters);
            //navigationService.Navigate("/UI/Pages/ShoppingListItemPage.xaml", parameters);
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
            return SelectedShoppingListItem != null;
        }

        /// <summary>
        /// Method to invoke when the Delete command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnDeleteExecute(object parameter)
        {
            var messageService = GetService<IMessageService>();
            if (messageService.Show("Are you sure that you want to remove the selected item?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                ShoppingList.Items.Remove(SelectedShoppingListItem);
                SelectedShoppingListItem = null;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the navigation has completed.
        /// </summary>
        /// <remarks>
        /// This should of course be a cleaner solution, but there is no other way to let a view-model
        /// know that navigation has completed. Another option is injection, but this would require every
        /// view-model for Windows Phone 7 to accept only the navigation context, which has actually nothing
        /// to do with the logic.
        /// <para/>
        /// It is also possible to use the <see cref="NavigationCompleted"/> event.
        /// </remarks>
        protected override void OnNavigationCompleted()
        {
            if (NavigationContext.ContainsKey("ShoppingListIndex"))
            {
                int.TryParse(NavigationContext["ShoppingListIndex"], out _shoppingListIndex);
            }

            if (_shoppingListIndex == -1)
            {
                ShoppingList = new Data.ShoppingList();
                UserData.Instance.ShoppingLists.Add(ShoppingList);
                _shoppingListIndex = UserData.Instance.ShoppingLists.IndexOf(ShoppingList);
            }
            else
            {
                ShoppingList = UserData.Instance.ShoppingLists[_shoppingListIndex];
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if successful; otherwise <c>false</c>.
        /// </returns>	
        protected override bool Save()
        {
            return true;
        }
        #endregion
    }
}
