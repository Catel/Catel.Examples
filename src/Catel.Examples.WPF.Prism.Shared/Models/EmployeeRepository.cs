namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<IEmployee> _employees = new List<IEmployee>();

        /// <summary>
        /// Gets the new id.
        /// </summary>
        /// <returns></returns>
        public int GetNewId()
        {
            lock (_employees)
            {
                return (from employee in _employees
                        orderby employee.Id descending
                        select employee.Id).FirstOrDefault() + 1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        public EmployeeRepository()
        {
            // Create dummy items
            _employees.Add(new Employee(1, "Geert", "van Horrik", 1));
            _employees.Add(new Employee(2, "Rajiv", "Mounguengue", 1));
            _employees.Add(new Employee(3, "John", "Doe", 2));
            _employees.Add(new Employee(4, "Vincent", "Skywalker", 2));
            _employees.Add(new Employee(5, "Jane", "Bauer", 3));
            _employees.Add(new Employee(6, "Kirsten", "Wright", 3));
        }

        /// <summary>
        /// Gets the employee by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IEmployee GetEmployeeById(int id)
        {
            lock (_employees)
            {
                return (from employee in _employees
                        where employee.Id == id
                        select employee).FirstOrDefault();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployee(IEmployee employee)
        {
            Argument.IsNotNull("employee", employee);

            lock (_employees)
            {
                _employees.Add(employee);
            }
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void DeleteEmployee(IEmployee employee)
        {
            Argument.IsNotNull("employee", employee);

            lock (_employees)
            {
                _employees.Remove(employee);
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEmployee> GetAllEmployees()
        {
            lock (_employees)
            {
                return (from employee in _employees
                        select employee);
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <param name="departmentName">Name of the department.</param>
        /// <returns></returns>
        public IEnumerable<IEmployee> GetAllEmployees(string departmentName)
        {
            Argument.IsNotNullOrWhitespace("departmentName", departmentName);

            lock (_employees)
            {
                return _employees.Where(r => r.Department.Name == departmentName);
            }
        }
    }
}