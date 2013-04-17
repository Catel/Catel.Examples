namespace Catel.Examples.WPF.ViewModelLifetime.Views
{
    using Catel.Windows;
    using MVVM;

    /// <summary>
    /// Interaction logic for CreateTabWindow.xaml.
    /// </summary>
    public partial class CreateTabWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTabWindow"/> class.
        /// </summary>
        public CreateTabWindow()
            : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTabWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public CreateTabWindow(IViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
