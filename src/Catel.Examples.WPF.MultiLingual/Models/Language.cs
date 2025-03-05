namespace Catel.Examples.MultiLingual.Models
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class Language : ValidatableModelBase
    {
        public Language()
        {
        }

        public Language(string name, string code)
        {
            Argument.IsNotNullOrWhitespace("name", name);
            Argument.IsNotNullOrWhitespace("code", code);

            Name = name;
            Code = code;
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Display
        {
            get { return $"{Name} ({Code})"; }
        }


        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Name), "Name cannot be empty"));
            }

            if (string.IsNullOrEmpty(Code))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(Code), "Code cannot be empty"));
            }
        }
    }
}
