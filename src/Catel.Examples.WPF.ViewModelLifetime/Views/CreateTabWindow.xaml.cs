namespace Catel.Examples.ViewModelLifetime.Views
{
    using MVVM;

    public partial class CreateTabWindow
    {
        #region Constructors
        public CreateTabWindow()
            : this(null)
        {
        }

        public CreateTabWindow(IViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
        #endregion
    }
}