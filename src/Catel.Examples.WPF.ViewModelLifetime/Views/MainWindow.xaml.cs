namespace Catel.Examples.ViewModelLifetime.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using Windows;
    using MVVM.Views;
    using Services;
    using System;

    public partial class MainWindow : ITabService
    {
        public MainWindow()
        {
            IoC.ServiceLocator.Default.RegisterInstance(typeof(ITabService), this);

            InitializeComponent();
        }

        public void AddTab(bool closeViewModelOnUnload)
        {
            var controlView = new ControlView();

            if (!closeViewModelOnUnload)
            {
                controlView.ViewModelLifetimeManagement = MVVM.ViewModelLifetimeManagement.PartlyManual;
            }

            var tabItem = new TabItem();
            tabItem.Header = CreateTabHeader(tabItem, closeViewModelOnUnload);
            tabItem.Content = controlView;

            tabControl.Items.Add(tabItem);

            tabControl.SetCurrentValue(System.Windows.Controls.Primitives.Selector.SelectedItemProperty, tabItem);
        }

        private static FrameworkElement CreateTabHeader(TabItem tabItem, bool closeViewModelOnUnload)
        {
            ArgumentNullException.ThrowIfNull(tabItem);

            var stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            var titleLabel = new Label();
            titleLabel.Content = string.Format("Close on unload: {0}", closeViewModelOnUnload);
            stackPanel.Children.Add(titleLabel);

            var closeButton = new Button();
            closeButton.Content = "X";
            closeButton.ToolTip = "Close";
            closeButton.Click += (sender, e) =>
            {
                var tabControl = tabItem.FindLogicalAncestorByType<System.Windows.Controls.TabControl>();
                if (tabControl is not null)
                {
                    var tabItemAsIUserControl = tabItem.Content as IUserControl;
                    if ((tabItemAsIUserControl is not null) && (tabItemAsIUserControl.ViewModel is not null))
                    {
                        tabItemAsIUserControl.ViewModel.CloseViewModelAsync(false);
                    }

                    tabControl.Items.Remove(tabItem);
                }
            };
            stackPanel.Children.Add(closeButton);

            return stackPanel;
        }
    }
}
