namespace Catel.Examples.WPF.Prism.Services
{
    using Models;

    /// <summary>
    /// Keeps track of department info.
    /// </summary>
    public interface IDepartmentTracker
    {
        IDepartment CurrentDepartment { get; set; }
    }
}