// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Language.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MultiLingual.Models
{
    using System;
    using System.Collections.Generic;
    using Data;

    [Serializable]
    public class Language : ValidatableModelBase
    {
        #region Constructors
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
        #endregion

        #region Properties
        public string Name { get; set; }

        public string Code { get; set; }

        public string Display
        {
            get { return $"{Name} ({Code})"; }
        }
        #endregion

        #region Methods
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
        #endregion
    }
}