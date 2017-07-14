// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Validation.ViewModels
{
    using System.Threading.Tasks;
    using Data;
    using IoC;
    using MVVM;
    using Services;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            Argument.IsNotNull(() => uiVisualizerService);

            _uiVisualizerService = uiVisualizerService;

            OpenValidationViaValidateMethods = new TaskCommand(OnOpenValidationViaValidateMethodsExecuteAsync);
            OpenValidationViaDataAnnotations = new TaskCommand(OnOpenValidationViaDataAnnotationsExecuteAsync);
            OpenValidationInModel = new TaskCommand(OnOpenValidationInModelExecuteAsync);
            OpenValidationInIValidator = new TaskCommand(OnOpenValidationInIValidatorExecuteAsync);

            Title = "Validation example";
        }
        #endregion

        #region Properties
        public bool EnableDeferValidationUntilFirstSave { get; set; }
        #endregion

        #region Commands
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
        #endregion
    }
}