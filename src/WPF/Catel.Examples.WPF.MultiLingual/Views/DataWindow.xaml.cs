// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MultiLingual.Views
{
    using Windows;

    public partial class DataWindow
    {
        #region Constructors
        public DataWindow()
            : base(DataWindowMode.OkCancelApply)
        {
            InitializeComponent();
        }
        #endregion
    }
}