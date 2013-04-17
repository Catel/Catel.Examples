using System;
using System.Collections.ObjectModel;
using Catel.Data;

namespace Catel.Examples.WP7.ShoppingList.Data
{
    public interface IShoppingList : IModel
    {
        DateTime DueDate { get; set; }

        string Name { get; set; }

        IShop Shop { get; set; }

        ObservableCollection<IShoppingListItem> Items { get; }
    }
}

