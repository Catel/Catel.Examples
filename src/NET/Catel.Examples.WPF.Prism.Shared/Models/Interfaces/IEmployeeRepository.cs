namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEmployee GetEmployeeById(int id);
        void AddEmployee(IEmployee employee);
        void DeleteEmployee(IEmployee employee);
        IEnumerable<IEmployee> GetAllEmployees();
        IEnumerable<IEmployee> GetAllEmployees(string departmentName);
        int GetNewId();
    }
}