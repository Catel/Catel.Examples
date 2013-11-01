// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShoppingList.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using System;
    using System.Collections.ObjectModel;
    using Catel.Data;

    public interface IShoppingList : IModel
    {
        #region Properties
        DateTime DueDate { get; set; }

        string Name { get; set; }

        IShop Shop { get; set; }

        ObservableCollection<IShoppingListItem> Items { get; }
        #endregion
    }
}