using Catel.Data;

namespace Catel.Examples.WP7.ShoppingList.Data
{
    public interface IShoppingListItem : IModel
    {
        bool Checked { get; set; }

        string Name { get; set; }

        int Quantity { get; set; }
    }
}
