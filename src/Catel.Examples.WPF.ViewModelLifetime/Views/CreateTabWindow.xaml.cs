namespace Catel.Examples.ViewModelLifetime.Views
{
    using MVVM;

    public partial class CreateTabWindow
    {
        public CreateTabWindow()
            : this(null)
        {
        }

        public CreateTabWindow(IViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
