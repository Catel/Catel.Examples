// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.ViewModelLifetime.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using Services;
    using Windows;
    using Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : DataWindow, ITabService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
            : base(DataWindowMode.Custom)
        {
            IoC.ServiceLocator.Default.RegisterInstance<ITabService>(this);

            InitializeComponent();
        }

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
                                                 tabItemAsIUserControl.ViewModel.CloseViewModel(false);
                                             }

                                             tabControl.Items.Remove(tabItem);
                                         }
                                     };
            stackPanel.Children.Add(closeButton);

            return stackPanel;
        }
    }
}