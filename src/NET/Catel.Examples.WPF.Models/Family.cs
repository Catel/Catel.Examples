namespace Catel.Examples.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Data;

#if !SILVERLIGHT
using System;
using System.Runtime.Serialization;
#endif

    /// <summary>
    /// Family Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class Family : SavableModelBase<Family>
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Family()
        { }

#if !SILVERLIGHT
        /// <summary>
        /// Initializes a new object based on <see cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the information.</param>
        /// <param name="context"><see cref="StreamingContext"/>.</param>
        protected Family(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
#endif
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the father.
        /// </summary>
        public Person Father
        {
            get { return GetValue<Person>(FatherProperty); }
            set { SetValue(FatherProperty, value); }
        }

        /// <summary>
        /// Register the property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FatherProperty = RegisterProperty("Father", typeof(Person), null);

        /// <summary>
        /// Gets or sets the mother.
        /// </summary>
        public Person Mother
        {
            get { return GetValue<Person>(MotherProperty); }
            set { SetValue(MotherProperty, value); }
        }

        /// <summary>
        /// Register the property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MotherProperty = RegisterProperty("Mother", typeof(Person), null);

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        public ObservableCollection<Person> Children
        {
            get { return GetValue<ObservableCollection<Person>>(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        /// <summary>
        /// Register the property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ChildrenProperty = RegisterProperty("Children", typeof(ObservableCollection<Person>), new ObservableCollection<Person>());
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Father == null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(FatherProperty, "No father in this family"));
            }

            if (Mother == null)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(MotherProperty, "No mother in this family"));
            }
        }
        #endregion
    }
}
