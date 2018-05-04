// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.ViewModelLifetime.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using Windows;
    using MVVM.Views;
    using Services;

    public partial class MainWindow : ITabService
    {
        #region Constructors
        public MainWindow()
        {
            IoC.ServiceLocator.Default.RegisterInstance(typeof(ITabService), this);

            InitializeComponent();
        }
        #endregion

        #region Methods
        public void AddTab(bool closeViewModelOnUnload)
        {
            var controlView = new ControlView();
            controlView.CloseViewModelOnUnloaded = closeViewModelOnUnload;

            var tabItem = new TabItem();
            tabItem.Header = CreateTabHeader(tabItem, closeViewModelOnUnload);
            tabItem.Content = controlView;

            tabControl.Items.Add(tabItem);
            tabControl.SelectedItem = tabItem;
        }

        private static FrameworkElement CreateTabHeader(TabItem tabItem, bool closeViewModelOnUnload)
        {
            Argument.IsNotNull("tabItem", tabItem);

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
                if (tabControl != null)
                {
                    var tabItemAsIUserControl = tabItem.Content as IUserControl;
                    if ((tabItemAsIUserControl != null) && (tabItemAsIUserControl.ViewModel != null))
                    {
                        tabItemAsIUserControl.ViewModel.CloseViewModelAsync(false);
                    }

                    tabControl.Items.Remove(tabItem);
                }
            };
            stackPanel.Children.Add(closeButton);

            return stackPanel;
        }
        #endregion
    }
}