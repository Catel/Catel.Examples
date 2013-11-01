// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManageShopsViewModel.cs" company="Catel development team">
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
    /// ManageShops view model.
    /// </summary>
    public class ManageShopsViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ManageShopsViewModel"/> class.
        /// </summary>
        public ManageShopsViewModel(INavigationService navigationService, IMessageService messageService)
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
            get { return "Shops"; }
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
        /// Register the Shops property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShopsProperty = RegisterProperty("Shops", typeof (ObservableCollection<IShop>));

        /// <summary>
        /// Register the SelectedShop property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedShopProperty = RegisterProperty("SelectedShop", typeof (IShop));
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
        /// Gets or sets the selected shop.
        /// </summary>
        public IShop SelectedShop
        {
            get { return GetValue<IShop>(SelectedShopProperty); }
            set { SetValue(SelectedShopProperty, value); }
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
        private void OnHomeExecute(object parameter)
        {
            SaveViewModel();

            _navigationService.Navigate<MainPageViewModel>();
        }

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnAddExecute(object parameter)
        {
            _navigationService.Navigate<ShopViewModel>();
            //navigationService.Navigate("/UI/Pages/ShopPage.xaml");
        }

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

            _navigationService.Navigate<ShopViewModel>(parameters);
            //navigationService.Navigate("/UI/Pages/ShopPage.xaml", parameters);
        }

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
            if (_messageService.Show("Are you sure that you want to remove the selected shop?", "Are you sure?", MessageButton.OKCancel) == MessageResult.OK)
            {
                Shops.Remove(SelectedShop);
                SelectedShop = null;
            }
        }
        #endregion

        #endregion
    }
}