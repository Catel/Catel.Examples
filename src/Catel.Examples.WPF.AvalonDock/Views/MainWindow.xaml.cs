namespace Catel.Examples.WPF.AvalonDock.Views
{
    using System.Text;
    using System.Windows;
    using System.Windows.Markup;
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();

            var xamlBuilder = new StringBuilder();
            xamlBuilder.AppendLine("<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            xamlBuilder.AppendLine("            xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"");
            xamlBuilder.AppendLine("            Orientation=\"Horizontal\">");
            xamlBuilder.AppendLine("  <TextBlock>test 1</TextBlock>");
            xamlBuilder.AppendLine("  <TextBlock>test 2</TextBlock>");
            xamlBuilder.AppendLine("</StackPanel>");

            var content = (UIElement)XamlReader.Parse(xamlBuilder.ToString());

            testStackPanel.Children.Add(content);
        }
    }
}
