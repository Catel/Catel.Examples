namespace Catel.Examples.Validation.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainWindowViewModel(IServiceProvider serviceProvider, IUIVisualizerService uiVisualizerService)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);
            _serviceProvider = serviceProvider;
            _uiVisualizerService = uiVisualizerService;

            OpenValidationViaValidateMethods = new TaskCommand(serviceProvider, OnOpenValidationViaValidateMethodsExecuteAsync);
            OpenValidationViaDataAnnotations = new TaskCommand(serviceProvider, OnOpenValidationViaDataAnnotationsExecuteAsync);
            OpenValidationInModel = new TaskCommand(serviceProvider, OnOpenValidationInModelExecuteAsync);

            Title = "Validation example";
        }

        public bool EnableDeferValidationUntilFirstSave { get; set; }

        public TaskCommand OpenValidationViaValidateMethods { get; private set; }

        private async Task OnOpenValidationViaValidateMethodsExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationWithValidateMethodsViewModel(null, _serviceProvider)
            {
                DeferValidationUntilFirstSaveCallWrapper = EnableDeferValidationUntilFirstSave
            });
        }

        public TaskCommand OpenValidationViaDataAnnotations { get; private set; }

        private async Task OnOpenValidationViaDataAnnotationsExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationWithDataAnnotationsViewModel(null, _serviceProvider)
            {
                DeferValidationUntilFirstSaveCallWrapper = EnableDeferValidationUntilFirstSave
            });
        }

        public TaskCommand OpenValidationInModel { get; private set; }

        private async Task OnOpenValidationInModelExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync(new ValidationInModelViewModel(null, _serviceProvider)
            {
                DeferValidationUntilFirstSaveCallWrapper = EnableDeferValidationUntilFirstSave
            });
        }
    }
}
