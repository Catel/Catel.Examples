namespace Catel.Examples.WPF.Prism.Models
{
    /// <summary>
    /// The department interface.
    /// </summary>
    public interface IDepartment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
    }
}