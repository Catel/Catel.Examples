namespace Catel.Examples.SL.PersonApplication.Views
{
    using ViewModels;
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for PersonWindow.xaml.
    /// </summary>
    public partial class PersonWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonWindow"/> class.
        /// </summary>
        public PersonWindow(PersonViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}

