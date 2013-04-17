namespace Catel.Examples.WPF.Memento.Views
{

    using Catel.Windows;
    using ViewModels;

    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonWindow"/> class.
        /// </summary>
        public PersonWindow(PersonViewModel viewModel)
            : base(viewModel, DataWindowMode.OkCancel, null, DataWindowDefaultButton.OK, true, InfoBarMessageControlGenerationMode.Inline)
        {
            AddCustomButton(new DataWindowButton("Generate data", viewModel.GenerateData));
            AddCustomButton(new DataWindowButton("Toggle error", viewModel.ToggleCustomError));

            InitializeComponent();
        }
    }
}
