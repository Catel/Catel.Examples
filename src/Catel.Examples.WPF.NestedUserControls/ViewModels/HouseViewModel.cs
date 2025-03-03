namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using Fody;
    using Models;
    using MVVM;

    public class HouseViewModel : ViewModelBase
    {
        public HouseViewModel(HouseModel house)
        {
            ArgumentNullException.ThrowIfNull(house);

            House = house;
        }

        public override string Title
        {
            get { return House.Name; }
        }

        [Model]
        [Expose("Name")]
        [Expose("Price")]
        [Expose("Rooms")]
        public HouseModel House { get; private set; }
    }
}
