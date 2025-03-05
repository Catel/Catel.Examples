namespace Catel.Examples.PersonApplication.Views
{
    using Windows;
    using ViewModels;

    public partial class PersonWindow
    {
        public PersonWindow(PersonViewModel viewModel)
            : base(viewModel, DataWindowMode.OkCancel, null, DataWindowDefaultButton.OK, true, InfoBarMessageControlGenerationMode.Inline)
        {
            AddCustomButton(new DataWindowButton("Generate data", viewModel.GenerateData));
            AddCustomButton(new DataWindowButton("Toggle error", viewModel.ToggleCustomError));

            InitializeComponent();
        }
    }
}
