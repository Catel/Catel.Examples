namespace Catel.Examples.Authentication.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Data;
    using MVVM;
    using Services;

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainViewModel(IUIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvider)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);
            ArgumentNullException.ThrowIfNull(authenticationProvider);

            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvider;

            RoleCollection = new ObservableCollection<string>(new[] {"Read-only", "Administrator"});

            ShowView = new TaskCommand(OnShowViewExecuteAsync, OnShowViewCanExecute);

            Title = "Authentication example";
        }
        #endregion

        #region Properties
        public ObservableCollection<string> RoleCollection { get; private set; }

        [Required]
        public string SelectedRole { get; set; }
        #endregion

        #region Commands
        public TaskCommand ShowView { get; private set; }

        private bool OnShowViewCanExecute()
        {
            return !string.IsNullOrEmpty(SelectedRole);
        }

        private async Task OnShowViewExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<ExampleViewModel>();
        }
        #endregion

        #region Methods
        private void OnSelectedRoleChanged()
        {
            // Dirty cast, normally this would be done via clean interfaces
            ((AuthenticationProvider) _authenticationProvider).Role = SelectedRole;
        }
        #endregion
    }
}
