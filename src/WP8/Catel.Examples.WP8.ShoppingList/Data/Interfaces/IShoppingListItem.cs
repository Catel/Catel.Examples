// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShoppingListItem.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using Catel.Data;

    public interface IShoppingListItem : IModel
    {
        #region Properties
        bool Checked { get; set; }

        string Name { get; set; }

        int Quantity { get; set; }
        #endregion
    }
}