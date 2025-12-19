namespace Catel.Examples.Authentication.Views
{
    using System;
    using Catel.Services;
    using Windows;

    public partial class ExampleView
    {
        public ExampleView(IServiceProvider serviceProvider, IWrapControlService wrapControlService, ILanguageService languageService)
            : base(serviceProvider, wrapControlService, languageService, DataWindowMode.Close)
        {
            InitializeComponent();
        }
    }
}
