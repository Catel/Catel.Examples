namespace Catel.Examples.WPF.MultiLingual.Views
{
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for DataWindow.xaml.
    /// </summary>
    public partial class DataWindow : Catel.Windows.DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataWindow"/> class.
        /// </summary>
        public DataWindow()
            : base(DataWindowMode.OkCancelApply)
        {
            InitializeComponent();
        }
    }
}