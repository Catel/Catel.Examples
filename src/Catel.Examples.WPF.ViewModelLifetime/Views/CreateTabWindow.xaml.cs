namespace Catel.Examples.ViewModelLifetime.Views
{
    using System;
    using Catel.Services;
    using MVVM;

    public partial class CreateTabWindow
    {
        public CreateTabWindow(IServiceProvider serviceProvider,
            IWrapControlService wrapControlService, ILanguageService languageService)
            : this(null, serviceProvider, wrapControlService, languageService)
        {
        }

        public CreateTabWindow(IViewModel viewModel, IServiceProvider serviceProvider,
            IWrapControlService wrapControlService, ILanguageService languageService)
            : base(viewModel, serviceProvider, wrapControlService, languageService)
        {
            InitializeComponent();
        }
    }
}
