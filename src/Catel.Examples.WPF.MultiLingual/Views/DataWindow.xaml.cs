namespace Catel.Examples.MultiLingual.Views
{
    using System;
    using Catel.Services;
    using Windows;

    public partial class DataWindow
    {
        partial void OnInitializingComponent()
        {
            Mode = DataWindowMode.OkCancelApply;
        }
    }
}
