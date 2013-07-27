namespace Catel.Examples.WPF.Prism.Models
{
    using System.Collections.Generic;

    public interface IDepartmentRepository
    {
        IDepartment GetDepartmentById(int id);
        void AddDepartment(IDepartment department);
        void DeleteDepartment(IDepartment department);
        IEnumerable<IDepartment> GetAllDepartments();
        int GetNewId();
    }
}