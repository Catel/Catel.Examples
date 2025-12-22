namespace Catel.Examples.PersonApplication.Views
{
    using Windows;
    using ViewModels;
    using Catel.Services;
    using System;

    public partial class PersonWindow
    {
        public PersonWindow(PersonViewModel viewModel, IServiceProvider serviceProvider,
            IWrapControlService wrapControlService, ILanguageService languageService)
            : base(viewModel, serviceProvider, wrapControlService, languageService)
        {
            Mode = DataWindowMode.OkCancel;
            DefaultButton = DataWindowDefaultButton.OK;
            InfoBarMessageControlGenerationMode = InfoBarMessageControlGenerationMode.Inline;

            AddCustomButton(new DataWindowButton("Generate data", nameof(PersonViewModel.GenerateData)));
            AddCustomButton(new DataWindowButton("Toggle error", nameof(PersonViewModel.ToggleCustomError)));

            InitializeComponent();
        }
    }
}
