namespace Catel.Examples.MultiLingual.Views
{
    using System;
    using Catel.Services;
    using Windows;

    public partial class DataWindow
    {
        public DataWindow(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService, DataWindowMode.OkCancelApply)
        {
            InitializeComponent();
        }
    }
}
