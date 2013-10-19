// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingListViewModel.cs" company="Catel development team">
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
    /// ShoppingList view model.
    /// </summary>
    public class ShoppingListViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        #endregion

        #region Variables
        private int _shoppingListIndex = -1;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListViewModel"/> class.
        /// </summary>
        public ShoppingListViewModel(INavigationService navigationService, IMessageService messageService)
        {
            _navigationService = navigationService;
            _messageService = messageService;

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
        public override string Title
        {
            get { return "Shopping list"; }
        }
        #endregion

        #region Models

        #region Constants
        /// <summary>
        /// Register the ShoppingList property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListProperty = RegisterProperty("ShoppingList", typeof (IShoppingList));
        #endregion

        #region Properties
        /// <summary>
        /// Gets the shopping list.
        /// </summary>
        [Model]
        public IShoppingList ShoppingList
        {
            get { return GetValue<IShoppingList>(ShoppingListProperty); }
            private set { SetValue(ShoppingListProperty, value); }
        }
        #endregion

        #endregion

        #region View model

        #region Constants
        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof (string));

        /// <summary>
        /// Register the ShoppingListItems property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListItemsProperty = RegisterProperty("ShoppingListItems", typeof (ObservableCollection<IShoppingListItem>));

        /// <summary>
        /// Register the SelectedShoppingListItem property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShoppingListItemProperty = RegisterProperty("SelectedShoppingListItem", typeof (IShoppingListItem));
        #endregion

        #region Properties
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
        /// Gets or sets the list of shopping list items.
        /// </summary>
        [ViewModelToModel("ShoppingList", "Items")]
        public ObservableCollection<IShoppingListItem> ShoppingListItems
        {
            get { return GetValue<ObservableCollection<IShoppingListItem>>(ShoppingListItemsProperty); }
            set { SetValue(ShoppingListItemsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected shopping list item.
        /// </summary>
        public IShoppingListItem SelectedShoppingListItem
        {
            get { return GetValue<IShoppingListItem>(SelectedShoppingListItemProperty); }
            set { SetValue(SelectedShoppingListItemProperty, value); }
        }
        #endregion

        #endregion

        #region Commands

        #region Properties
        /// <summary>
        /// Gets the Back command.
        /// </summary>
        public Command<object> Back { get; private set; }

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
        /// Method to invoke when the Back command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnBackExecute(object parameter)
        {
            _navigationService.Navigate<ManageShoppingListsViewModel>();
        }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnAddExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("ShoppingListIndex", _shoppingListIndex);

            _navigationService.Navigate<ShoppingListItemViewModel>(parameters);
        }

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

            _navigationService.Navigate<ShoppingListItemViewModel>(parameters);
        }

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
            if (_messageService.Show("Are you sure that you want to remove the selected item?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                ShoppingList.Items.Remove(SelectedShoppingListItem);
                SelectedShoppingListItem = null;
            }
        }
        #endregion

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