using System;
using Catel.Data;
using Catel.Examples.WP7.ShoppingList.Data;
using Catel.MVVM;
using Catel.MVVM.Services;

namespace Catel.Examples.WP7.ShoppingList.ViewModels
{
    /// <summary>
    /// ShoppingListItem view model.
    /// </summary>
    public class ShoppingListItemViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Variables
        private int _shoppingListIndex = -1;
        private int _shoppingListItemIndex = -1;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListItemViewModel"/> class.
        /// </summary>
        public ShoppingListItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OK = new Command<object, object>(OnOKExecute, OnOKCanExecute);
            Cancel = new Command<object>(OnCancelExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Shopping list item"; } }

        #region Models
        /// <summary>
        /// Gets the shopping list item.
        /// </summary>
        [Model]
        public IShoppingListItem ShoppingListItem
        {
            get { return GetValue<IShoppingListItem>(ShoppingListItemProperty); }
            private set { SetValue(ShoppingListItemProperty, value); }
        }

        /// <summary>
        /// Register the ShoppingListItem property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListItemProperty = RegisterProperty("ShoppingListItem", typeof(IShoppingListItem));
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ViewModelToModel("ShoppingListItem")]
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
        /// Gets or sets the quantity.
        /// </summary>
        [ViewModelToModel("ShoppingListItem")]
        public int Quantity
        {
            get { return GetValue<int>(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        /// <summary>
        /// Register the Quantity property so it is known in the class.
        /// </summary>
        public static readonly PropertyData QuantityProperty = RegisterProperty("Quantity", typeof(int));
        #endregion
        #endregion

        #region Commands
        /// <summary>
        /// Gets the OK command.
        /// </summary>
        public Command<object, object> OK { get; private set; }

        /// <summary>
        /// Method to check whether the OK command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnOKCanExecute(object parameter)
        {
            return !ShoppingListItem.HasErrors;
        }

        /// <summary>
        /// Method to invoke when the OK command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnOKExecute(object parameter)
        {
            _navigationService.GoBack();
        }

        /// <summary>
        /// Gets the Cancel command.
        /// </summary>
        public Command<object> Cancel { get; private set; }

        /// <summary>
        /// Method to invoke when the Cancel command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnCancelExecute(object parameter)
        {
            CancelViewModel();

            _navigationService.GoBack();
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
            if (!NavigationContext.ContainsKey("ShoppingListIndex"))
            {
                throw new Exception("ShoppingListIndex is a mandatory argument");
            }

            int.TryParse(NavigationContext["ShoppingListIndex"], out _shoppingListIndex);

            if (NavigationContext.ContainsKey("ShoppingListItemIndex"))
            {
                int.TryParse(NavigationContext["ShoppingListItemIndex"], out _shoppingListItemIndex);
            }

            ShoppingListItem = _shoppingListItemIndex != -1 ? UserData.Instance.ShoppingLists[_shoppingListIndex].Items[_shoppingListItemIndex] : new ShoppingListItem();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if successful; otherwise <c>false</c>.
        /// </returns>	
        protected override bool Save()
        {
            if (_shoppingListItemIndex == -1)
            {
                UserData.Instance.ShoppingLists[_shoppingListIndex].Items.Add(ShoppingListItem);
                _shoppingListItemIndex = UserData.Instance.ShoppingLists[_shoppingListIndex].Items.IndexOf(ShoppingListItem);
            }

            return true;
        }
        #endregion
    }
}
