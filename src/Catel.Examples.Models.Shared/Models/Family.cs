namespace Catel.Examples.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Collections;
    using Data;

    [Serializable]
    public class Family : ValidatableModelBase
    {
        public Family()
        {
            Children = new FastObservableCollection<Person>();
        }

        public Person Father { get; set; }

        public Person Mother { get; set; }

        public ObservableCollection<Person> Children { get; set; }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Father is null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(nameof(Father), "No father in this family"));
            }

            if (Mother is null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(nameof(Mother), "No mother in this family"));
            }
        }
    }
}
