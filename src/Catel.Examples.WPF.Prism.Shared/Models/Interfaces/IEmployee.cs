namespace Catel.Examples.WPF.Prism.Models
{
    /// <summary>
    /// The employee interface.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        /// <remarks>
        /// This is a wrapper by using the <see cref="IDepartmentRepository"/> and the <see cref="DepartmentId"/>/
        /// </remarks>
        IDepartment Department { get; set; }
    }
}