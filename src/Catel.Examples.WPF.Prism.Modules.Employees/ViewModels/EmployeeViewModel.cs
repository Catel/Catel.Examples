namespace Catel.Examples.WPF.Prism.Modules.Employees.ViewModels
{
    using System;
    using Collections;
    using Data;
    using MVVM;
    using Models;
    using ViewModelBase = Prism.ViewModels.ViewModelBase;

    /// <summary>
    /// Employee view model.
    /// </summary>
    public class EmployeeViewModel : ViewModelBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeViewModel"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">The <paramref name="employee"/> is <c>null</c>.</exception>
        public EmployeeViewModel(IEmployee employee)
        {
            Argument.IsNotNull("employee", employee);

            Employee = employee;

            var departmentRepository = GetService<IDepartmentRepository>();
            AvailableDepartments = new FastObservableCollection<IDepartment>(departmentRepository.GetAllDepartments());
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        /// <remarks></remarks>
        public override string Title
        {
            get { return "Employee"; }
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        [Model]
        [Expose("FirstName")]
        [Expose("LastName")]
        [Expose("Department")]
        public IEmployee Employee
        {
            get { return GetValue<Employee>(EmployeeProperty); }
            private set { SetValue(EmployeeProperty, value); }
        }

        /// <summary>
        /// Register the Employee property so it is known in the class.
        /// </summary>
        public static readonly PropertyData EmployeeProperty = RegisterProperty("Employee", typeof (Employee));

        /// <summary>
        /// Gets the department.
        /// </summary>
        [Model]
        [ViewModelToModel("Employee")]
        public IDepartment Department
        {
            get { return GetValue<Department>(DepartmentProperty); }
            private set { SetValue(DepartmentProperty, value); }
        }

        /// <summary>
        /// Register the Employee property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DepartmentProperty = RegisterProperty("Department", typeof (Department));

        /// <summary>
        /// Gets or sets the Departments.
        /// </summary>
        public FastObservableCollection<IDepartment> AvailableDepartments
        {
            get { return GetValue<FastObservableCollection<IDepartment>>(AvailableDepartmentsProperty); }
            private set { SetValue(AvailableDepartmentsProperty, value); }
        }

        /// <summary>
        /// Register the Departments property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AvailableDepartmentsProperty = RegisterProperty("AvailableDepartments", typeof (FastObservableCollection<IDepartment>));
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}