// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Family.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Collections;
    using Data;

    [Serializable]
    public class Family : ValidatableModelBase
    {
        #region Constructors
        public Family()
        {
            Children = new FastObservableCollection<Person>();
        }

#if !NETFX_CORE
        protected Family(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
        #endregion

        #region Properties
        public Person Father { get; set; }

        public Person Mother { get; set; }

        public ObservableCollection<Person> Children { get; set; }
        #endregion

        #region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Father == null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(nameof(Father), "No father in this family"));
            }

            if (Mother == null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(nameof(Mother), "No mother in this family"));
            }
        }
        #endregion
    }
}