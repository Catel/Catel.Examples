namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;
    using Data;
    using IoC;

    /// <summary>
    /// Department Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    public class Department : ModelBase, IDepartment
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Department()
            : this(0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Department(int id, string name)
        {
            if (id <= 0)
            {
                var repository = ServiceLocator.Default.ResolveType<IDepartmentRepository>();
                Id = repository.GetNewId();
            }
            else
            {
                Id = id;
            }

            Name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        /// <summary>
        /// Register the Id property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IdProperty = RegisterProperty("Id", typeof(int), 0);

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        /// <summary>
        /// Register the Name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof (string), string.Empty);
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        /// <remarks></remarks>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(Name))
            {
                validationResults.Add(FieldValidationResult.CreateError(NameProperty, "'Name' is required"));
            }
        }
        #endregion
    }
}