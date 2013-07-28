// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
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
        #region Constructors
        public MainWindow()
            : base(DataWindowMode.Custom, null, DataWindowDefaultButton.None, true, InfoBarMessageControlGenerationMode.Inline)
        {
            InitializeComponent();
        }
        #endregion
    }
}