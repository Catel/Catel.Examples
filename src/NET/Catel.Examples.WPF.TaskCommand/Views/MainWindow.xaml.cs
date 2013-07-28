// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Taggersoft">
//   Copyright (c) 2008 - 2013 Taggersoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.TaskCommand.Views
{
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
            : base(DataWindowMode.Custom, null, DataWindowDefaultButton.None, true, InfoBarMessageControlGenerationMode.Inline)
        {
            InitializeComponent();
        }
    }
}