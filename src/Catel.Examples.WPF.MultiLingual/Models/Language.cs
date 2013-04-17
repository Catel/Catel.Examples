namespace Catel.Examples.WPF.MultiLingual.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Data;

    /// <summary>
    /// Language Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    [Serializable]
    public class Language : ModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language() { }

        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <exception cref="ArgumentException">The <paramref name="name"/> is <c>null</c> or whitespace.</exception>
        /// <exception cref="ArgumentException">The <paramref name="code"/> is <c>null</c> or whitespace.</exception>
        public Language(string name, string code)
        {
            Argument.IsNotNullOrWhitespace("name", name);
            Argument.IsNotNullOrWhitespace("code", code);

            Name = name;
            Code = code;
        }

        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Language(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the language.
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

        /// <summary>
        /// Gets or sets the code of the language.
        /// </summary>
        public string Code
        {
            get { return GetValue<string>(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        /// <summary>
        /// Register the Code property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CodeProperty = RegisterProperty("Code", typeof(string), string.Empty);

        /// <summary>
        /// Gets the display value.
        /// </summary>
        /// <value>The display.</value>
        public string Display
        {
            get { return string.Format("{0} ({1})", Name, Code); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "Name cannot be empty"));
            }

            if (string.IsNullOrEmpty(Code))
            {
                validationResults.Add(FieldValidationResult.CreateError(CodeProperty, "Code cannot be empty"));
            }
        }
        #endregion
    }
}
