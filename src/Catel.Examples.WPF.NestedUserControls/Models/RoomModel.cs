namespace Catel.Examples.NestedUserControls.Models
{
    using System.Collections.Generic;
    using Data;

    public class RoomModel : ValidatableModelBase
    {
        public RoomModel()
        {
        }

        public RoomModel(string name)
            : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Name), "Name of room is required"));
            }
        }
    }
}
