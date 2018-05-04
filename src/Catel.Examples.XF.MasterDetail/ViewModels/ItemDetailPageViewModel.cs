namespace Catel.Examples.Xamarin.Forms.MasterDetail.ViewModels
{
    using Catel.Examples.Xamarin.Forms.MasterDetail.Models;
    using Catel.MVVM;

    public class ItemDetailPageViewModel : ViewModelBase
    {
        public ItemDetailPageViewModel(Item item)
        {
            Item = item;
        }

        [Model]
        public Item Item { get; set; }

        [ViewModelToModel("Item")]
        public string Description { get; set; }

        [ViewModelToModel("Item")]
        public string Text { get; set; }

        public override string Title => Item?.Text;

        public int Quantity { get; set; } = 1;
    }
}