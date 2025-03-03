namespace Catel.Examples.NestedUserControls.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Data;

    public class HouseModel : ValidatableModelBase
    {
        public HouseModel()
        {
            Rooms = new ObservableCollection<RoomModel>();
        }

        public HouseModel(string name, decimal price)
            : this()
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ObservableCollection<RoomModel> Rooms { get; set; }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Name), "Name of house is required"));
            }
        }
    }
}
