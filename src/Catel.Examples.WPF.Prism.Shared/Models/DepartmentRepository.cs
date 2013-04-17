namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<IDepartment> _departments = new List<IDepartment>();

        /// <summary>
        /// Gets the new id.
        /// </summary>
        /// <returns></returns>
        public int GetNewId()
        {
            lock (_departments)
            {
                return (from department in _departments
                        orderby department.Id descending 
                        select department.Id).FirstOrDefault() + 1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        public DepartmentRepository()
        {
            // Create dummy items
            _departments.Add(new Department(1, "IT"));
            _departments.Add(new Department(2, "Human Resources"));
            _departments.Add(new Department(3, "Billing"));
        }

        /// <summary>
        /// Gets the department by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IDepartment GetDepartmentById(int id)
        {
            lock (_departments)
            {
                return (from department in _departments
                        where department.Id == id
                        select department).FirstOrDefault();
            }
        }

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="department">The department.</param>
        public void AddDepartment(IDepartment department)
        {
            Argument.IsNotNull("department", department);

            lock (_departments)
            {
                _departments.Add(department);
            }
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="department">The department.</param>
        public void DeleteDepartment(IDepartment department)
        {
            Argument.IsNotNull("department", department);

            lock (_departments)
            {
                _departments.Remove(department);
            }
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDepartment> GetAllDepartments()
        {
            lock (_departments)
            {
                return (from department in _departments
                        select department);
            }
        }
    }
}