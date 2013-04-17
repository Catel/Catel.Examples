namespace Catel.Examples.WPF.Analytics.Views
{
    using Windows;

    /// <summary>
    ///   Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : DataWindow
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();
        }
    }
}