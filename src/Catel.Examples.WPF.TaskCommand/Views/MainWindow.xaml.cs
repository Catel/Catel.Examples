namespace Catel.Examples.TaskCommand.Views
{
    using System;
    using Catel.Services;

    public partial class MainWindow
    {
        public MainWindow(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService)
        {
            InitializeComponent();
        }
    }
}
