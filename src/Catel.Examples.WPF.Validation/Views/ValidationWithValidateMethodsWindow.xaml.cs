namespace Catel.Examples.Validation.Views
{
    using System;
    using Catel.Services;

    public partial class ValidationWithValidateMethodsWindow
    {
        public ValidationWithValidateMethodsWindow(IServiceProvider serviceProvider,
            IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService)
        {
            InitializeComponent();
        }
    }
}
