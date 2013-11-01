// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShop.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WP8.ShoppingList.Data
{
    using Catel.Data;

    public interface IShop : IModel
    {
        #region Properties
        string Name { get; set; }
        #endregion
    }
}