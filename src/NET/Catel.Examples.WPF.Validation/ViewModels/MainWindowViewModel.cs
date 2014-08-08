namespace Catel.Examples.WPF.Validation.ViewModels
{
    using System;
    using Catel.IoC;
    using Catel.MVVM;
    using Data;
    using Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;

            OpenValidationViaValidateMethods = new Command(OnOpenValidationViaValidateMethodsExecute);
            OpenValidationViaDataAnnotations = new Command(OnOpenValidationViaDataAnnotationsExecute);
            OpenValidationInModel = new Command(OnOpenValidationInModelExecute);
            OpenValidationInIValidator = new Command(OnOpenValidationInIValidatorExecute);
            OpenValidationViaFluentValidation = new Command(OpenValidationViaFluentValidationExecute);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Validation example"; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the validation should defer until the first save.
        /// </summary>
        public bool EnableDeferValidationUntilFirstSave
        {
            get { return GetValue<bool>(EnableDeferValidationUntilFirstSaveProperty); }
            set { SetValue(EnableDeferValidationUntilFirstSaveProperty, value); }
        }

        /// <summary>
        /// Register the EnableDeferValidationUntilFirstSave property so it is known in the class.
        /// </summary>
        public static readonly PropertyData EnableDeferValidationUntilFirstSaveProperty = RegisterProperty("EnableDeferValidationUntilFirstSave", typeof(bool));
        #endregion

        #region Commands
        /// <summary>
        /// Gets the OpenValidationViaValidateMethods command.
        /// </summary>
        public Command OpenValidationViaValidateMethods { get; private set; }

        /// <summary>
        /// Method to invoke when the OpenValidationViaValidateMethods command is executed.
        /// </summary>
        private void OnOpenValidationViaValidateMethodsExecute()
        {
            _uiVisualizerService.ShowDialog(new ValidationWithValidateMethodsViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        /// <summary>
        /// Gets the OpenValidationViaDataAnnotations command.
        /// </summary>
        public Command OpenValidationViaDataAnnotations { get; private set; }

        /// <summary>
        /// Method to invoke when the OpenValidationViaDataAnnotations command is executed.
        /// </summary>
        private void OnOpenValidationViaDataAnnotationsExecute()
        {
            _uiVisualizerService.ShowDialog(new ValidationWithDataAnnotationsViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        /// <summary>
        /// Gets the OpenValidationInModel command.
        /// </summary>
        public Command OpenValidationInModel { get; private set; }

        /// <summary>
        /// Method to invoke when the OpenValidationInModel command is executed.
        /// </summary>
        private void OnOpenValidationInModelExecute()
        {
            _uiVisualizerService.ShowDialog(new ValidationInModelViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        /// <summary>
        /// Gets the OpenValidationInIValidator command.
        /// </summary>
        public Command OpenValidationInIValidator { get; private set; }

        /// <summary>
        /// Method to invoke when the OpenValidationInIValidator command is executed.
        /// </summary>
        private void OnOpenValidationInIValidatorExecute()
        {
            _uiVisualizerService.ShowDialog(new ValidationInIValidatorViewModel(null, EnableDeferValidationUntilFirstSave));
        }

        public Command OpenValidationViaFluentValidation { get; private set; }

        /// <summary>
        /// Method to invoke when the OpenValidationViaFluentValidator command is executed.
        /// </summary>
        private void OpenValidationViaFluentValidationExecute()
        {
            var typeFactory = TypeFactory.Default;
            var vm = typeFactory.CreateInstanceWithParametersAndAutoCompletion<ValidationWithFluentValidationViewModel>(null, true);

            _uiVisualizerService.ShowDialog(vm);
        }

        #endregion
    }
}
