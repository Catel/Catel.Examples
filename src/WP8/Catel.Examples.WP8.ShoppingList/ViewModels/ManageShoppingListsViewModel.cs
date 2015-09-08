// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageShoppingListsViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Catel.Data;
    using Catel.Examples.WP8.ShoppingList.Data;
    using Catel.MVVM;
    using Catel.Services;

    /// <summary>
    /// ManageShopingLists view model.
    /// </summary>
    public class ManageShoppingListsViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageShoppingListsViewModel"/> class.
        /// </summary>
        public ManageShoppingListsViewModel(INavigationService navigationService, IMessageService messageService)
            : base(false)
        {
            _navigationService = navigationService;
            _messageService = messageService;

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
        public override string Title
        {
            get { return "Shopping lists"; }
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
        private UserData UserData
        {
            get { return GetValue<UserData>(UserDataProperty); }
            set { SetValue(UserDataProperty, value); }
        }
        #endregion

        #endregion

        #region View model

        #region Constants
        /// <summary>
        /// Register the ShoppingLists property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListsProperty = RegisterProperty("ShoppingLists", typeof (ObservableCollection<IShoppingList>));

        /// <summary>
        /// Register the SelectedShoppingList property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShoppingListProperty = RegisterProperty("SelectedShoppingList", typeof (IShoppingList));
        #endregion

        #region Properties
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
        /// Gets the Home command.
        /// </summary>
        public Command<object> Home { get; private set; }

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public Command<object> Add { get; private set; }

        /// <summary>
        /// Gets the Edit command.
        /// </summary>
        public Command<object, object> Edit { get; private set; }

        /// <summary>
        /// Gets the Delete command.
        /// </summary>
        public Command<object, object> Delete { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Method to invoke when the Home command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private async void OnHomeExecute(object parameter)
        {
            await SaveViewModelAsync();

            _navigationService.Navigate<MainPageViewModel>();
        }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnAddExecute(object parameter)
        {
            _navigationService.Navigate<ShoppingListViewModel>();
        }

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

            _navigationService.Navigate<ShoppingListViewModel>(parameters);
        }

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
        private async void OnDeleteExecute(object parameter)
        {
            if (await _messageService.ShowAsync("Are you sure that you want to remove the selected shopping list?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                ShoppingLists.Remove(SelectedShoppingList);
                SelectedShoppingList = null;
            }
        }
        #endregion

        #endregion
    }
}