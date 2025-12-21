namespace Catel.Examples.NestedUserControls.Views
{
    using System;
    using Catel.Services;

    public partial class DemoWindow
    {
        public DemoWindow(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService)
        { 
            InitializeComponent();
        }
    }
}
