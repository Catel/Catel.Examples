namespace Catel.Examples.WPF.Prism.Views
{
    using Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class ShellView : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellView"/> class.
        /// </summary>
        public ShellView()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();
        }
    }
}