﻿namespace Catel.Examples.AdvancedDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Data;

    /// <summary>
    /// RoomModel Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
[Serializable]
#endif
    public class RoomModel : ModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomModel"/> class.
        /// </summary>
        public RoomModel()
        {
        }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        /// <param name="name">The name.</param>
        public RoomModel(string name)
            : this()
        {
            Name = name;
        }

#if !SILVERLIGHT	
    /// <summary>
    /// Initializes a new object based on <see cref="SerializationInfo"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected RoomModel(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
#endif
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), string.Empty);
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "Name of room is required"));
            }
        }
        #endregion
    }
}
