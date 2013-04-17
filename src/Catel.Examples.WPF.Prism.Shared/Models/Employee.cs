namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;
    using Data;
    using IoC;

    /// <summary>
    /// Employee Data object class which fully supports serialization, property changed notifications,
    /// backwards compatibility and error checking.
    /// </summary>
    public class Employee : ModelBase, IEmployee
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new object from scratch.
        /// </summary>
        public Employee()
            : this(0, null, null, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="departmentId">The department id.</param>
        public Employee(int id, string firstName, string lastName, int departmentId)
        {
            if (id <= 0)
            {
                var repository = ServiceLocator.Default.ResolveType<IEmployeeRepository>();
                Id = repository.GetNewId();
            }
            else
            {
                Id = id;
            }

            FirstName = firstName;
            LastName = lastName;
            DepartmentId = departmentId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            private set { SetValue(IdProperty, value); }
        }

        /// <summary>
        /// Register the Id property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IdProperty = RegisterProperty("Id", typeof(int), 0);

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

        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        public int DepartmentId
        {
            get { return GetValue<int>(DepartmentIdProperty); }
            set { SetValue(DepartmentIdProperty, value); }
        }

        /// <summary>
        /// Register the DepartmentId property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DepartmentIdProperty = RegisterProperty("DepartmentId", typeof(int), 0,
            (sender, e) => ((Employee)sender).RaisePropertyChanged("Department"));

        /// <summary>
        /// Gets or sets the department. The value will be <c>null</c> when the user does not belong to a department.
        /// </summary>
        /// <value>The department.</value>
        /// <remarks>
        /// This is a wrapper by using the <see cref="IDepartmentRepository"/> and the <see cref="DepartmentId"/>/
        /// </remarks>
        public IDepartment Department
        {
            get
            {
                var repository = ServiceLocator.Default.ResolveType<IDepartmentRepository>();
                return repository.GetDepartmentById(DepartmentId);
            }
            set
            {
                DepartmentId = (!ObjectHelper.IsNull(value)) ? value.Id : 0;
            }
        }
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
            if (string.IsNullOrEmpty(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(FirstNameProperty, "'First name' is required"));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(LastNameProperty, "'Last name' is required"));
            }

            if (ObjectHelper.IsNull(Department))
            {
                validationResults.Add(FieldValidationResult.CreateError("DepartmentId", "'Department' is required"));
            }
        }
        #endregion
    }
}