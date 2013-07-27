namespace Catel.Examples.AdvancedDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Data;

    /// <summary>
    /// PersonModel Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class PersonModel : ModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public PersonModel() { }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected PersonModel(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
#endif
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Register the FirstName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string), string.Empty);

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName
        {
            get { return GetValue<string>(MiddleNameProperty); }
            set { SetValue(MiddleNameProperty, value); }
        }

        /// <summary>
        /// Register the MiddleName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MiddleNameProperty = RegisterProperty("MiddleName", typeof(string), string.Empty);

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get { return GetValue<string>(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        /// <summary>
        /// Register the LastName property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LastNameProperty = RegisterProperty("LastName", typeof(string), string.Empty);
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(FirstNameProperty, "First name is required"));
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(LastNameProperty, "Last name is required"));
            }
        }
        #endregion
    }
}
