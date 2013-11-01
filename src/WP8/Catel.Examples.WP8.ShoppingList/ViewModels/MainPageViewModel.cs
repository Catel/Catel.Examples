// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Catel.Data;
    using Catel.Examples.WP8.ShoppingList.Data;
    using Catel.MVVM;
    using Catel.MVVM.Services;

    /// <summary>
    /// MainPage view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel(INavigationService navigationService)
            : base(false)
        {
            _navigationService = navigationService;
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
        public override string Title
        {
            get { return "Shopping cart"; }
        }
        #endregion

        #region Models

        #region Constants
        /// <summary>
        /// Register the UserData property so it is known in the class.
        /// </summary>
        public static readonly PropertyData UserDataProperty = RegisterProperty("UserData", typeof (UserData));
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        [Model]
        protected UserData UserData
        {
            get { return GetValue<UserData>(UserDataProperty); }
            set { SetValue(UserDataProperty, value); }
        }
        #endregion

        #endregion

        #region View model

        #region Constants
        /// <summary>
        /// Register the Shops property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShopsProperty = RegisterProperty("Shops", typeof (ObservableCollection<IShop>));

        /// <summary>
        /// Register the ShoppingLists property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListsProperty = RegisterProperty("ShoppingLists", typeof (ObservableCollection<IShoppingList>));

        /// <summary>
        /// Register the SelectedShoppingList property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShoppingListProperty = RegisterProperty("SelectedShoppingList", typeof (IShoppingList),
            null, (sender, e) => ((MainPageViewModel) sender).OnSelectedShoppingListChanged());
        #endregion

        #region Properties
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
        /// Gets or sets the list of shopping lists.
        /// </summary>
        [ViewModelToModel("UserData")]
        public ObservableCollection<IShoppingList> ShoppingLists
        {
            get { return GetValue<ObservableCollection<IShoppingList>>(ShoppingListsProperty); }
            set { SetValue(ShoppingListsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected shopping list.
        /// </summary>
        public IShoppingList SelectedShoppingList
        {
            get { return GetValue<IShoppingList>(SelectedShoppingListProperty); }
            set { SetValue(SelectedShoppingListProperty, value); }
        }
        #endregion

        #endregion

        #region Commands

        #region Properties
        /// <summary>
        /// Gets the ManageShops command.
        /// </summary>
        public Command<object> ManageShops { get; private set; }

        /// <summary>
        /// Gets the ManageShoppingLists command.
        /// </summary>
        public Command<object> ManageShoppingLists { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Method to invoke when the ManageShops command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnManageShopsExecute(object parameter)
        {
            _navigationService.Navigate<ManageShopsViewModel>();
        }

        /// <summary>
        /// Method to invoke when the ManageShoppingLists command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnManageShoppingListsExecute(object parameter)
        {
            _navigationService.Navigate<ManageShoppingListsViewModel>();
        }
        #endregion

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

                _navigationService.Navigate<ShoppingListViewModel>(parameters);
            }
        }
        #endregion
    }
}