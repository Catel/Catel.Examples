// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserData.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.IO.IsolatedStorage;
    using Catel.Data;
    using Catel.Logging;

    public class UserData : SavableModelBase<UserData>
    {
        #region Variables
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes the <see cref="UserData"/> class.
        /// </summary>
        static UserData()
        {
            try
            {
                using (var isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isolatedStorageFile.FileExists("UserData.dob"))
                    {
                        using (var isolatedStorageFileStream = isolatedStorageFile.OpenFile("UserData.dob", FileMode.Open, FileAccess.Read))
                        {
                            Instance = Load(isolatedStorageFileStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            if (Instance == null)
            {
                Instance = new UserData();
            }
        }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public UserData()
        {
            Shops = new ObservableCollection<IShop>();
            ShoppingLists = new ObservableCollection<IShoppingList>();

            // Demo data
            var shop = new Shop("Geerts gadget shop");
            Shops.Add(shop);

            var shoppingList = new ShoppingList();
            shoppingList.Name = "Geerts wishlist";
            shoppingList.Shop = shop;
            shoppingList.DueDate = DateTime.Now.AddDays(1);
            ShoppingLists.Add(shoppingList);

            var xoom = new ShoppingListItem("Motorola Xoom tablet", 1);
            var windowsPhone = new ShoppingListItem("Windows Phone 7", 1);

            shoppingList.Items.Add(xoom);
            shoppingList.Items.Add(windowsPhone);
        }
        #endregion

        #region Constants
        /// <summary>
        /// Register the Shops property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShopsProperty = RegisterProperty("Shops", typeof (ObservableCollection<IShop>), null);

        /// <summary>
        /// Register the ShoppingLists property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ShoppingListsProperty = RegisterProperty("ShoppingLists", typeof (ObservableCollection<IShoppingList>), null);
        #endregion

        #region Properties
        /// <summary>
        /// Gets the instance if this singleton class.
        /// </summary>
        /// <value>The instance.</value>
        public static UserData Instance { get; private set; }

        /// <summary>
        /// Gets or sets the list of shops.
        /// </summary>
        public ObservableCollection<IShop> Shops
        {
            get { return GetValue<ObservableCollection<IShop>>(ShopsProperty); }
            set { SetValue(ShopsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the list of shopping lists.
        /// </summary>
        public ObservableCollection<IShoppingList> ShoppingLists
        {
            get { return GetValue<ObservableCollection<IShoppingList>>(ShoppingListsProperty); }
            set { SetValue(ShoppingListsProperty, value); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves the data into the isolated storage.
        /// </summary>
        public void Save()
        {
            using (var isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var isolatedStorageFileStream = isolatedStorageFile.OpenFile("UserData.dob", FileMode.Create, FileAccess.ReadWrite))
                {
                    Save(isolatedStorageFileStream);
                }
            }
        }
        #endregion
    }
}