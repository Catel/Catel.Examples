namespace Catel.Examples.Validation.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;

            OpenValidationViaValidateMethods = new TaskCommand(OnOpenValidationViaValidateMethodsExecuteAsync);
            OpenValidationViaDataAnnotations = new TaskCommand(OnOpenValidationViaDataAnnotationsExecuteAsync);
            OpenValidationInModel = new TaskCommand(OnOpenValidationInModelExecuteAsync);
            OpenValidationInIValidator = new TaskCommand(OnOpenValidationInIValidatorExecuteAsync);

            Title = "Validation example";
        }

        public bool EnableDeferValidationUntilFirstSave { get; set; }

        public TaskCommand OpenValidationViaValidateMethods { get; private set; }

        private async Task OnOpenValidationViaValidateMethodsExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationWithValidateMethodsViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        public TaskCommand OpenValidationViaDataAnnotations { get; private set; }

        private async Task OnOpenValidationViaDataAnnotationsExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationWithDataAnnotationsViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        public TaskCommand OpenValidationInModel { get; private set; }

        private async Task OnOpenValidationInModelExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationInModelViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        public TaskCommand OpenValidationInIValidator { get; private set; }

        private async Task OnOpenValidationInIValidatorExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationInIValidatorViewModel(null, EnableDeferValidationUntilFirstSave));
        }
    }
}
