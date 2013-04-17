namespace Catel.Examples.WPF.Prism.Modules.Employees.Views
{
    using MVVM;
    using Windows;

    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml.
    /// </summary>
    public partial class EmployeeWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public EmployeeWindow(IViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeWindow"/> class.
        /// </summary>
        public EmployeeWindow()
            : this(null)
        {
        }
    }
}