namespace Catel.Examples.Authentication.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainViewModel(IServiceProvider serviceProvider, 
            IUIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvider)
            : base(serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);
            ArgumentNullException.ThrowIfNull(authenticationProvider);

            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvider;

            RoleCollection = new ObservableCollection<string>(new[] {"Read-only", "Administrator"});

            ShowView = new TaskCommand(serviceProvider, OnShowViewExecuteAsync, OnShowViewCanExecute);

            Title = "Authentication example";
        }

        public ObservableCollection<string> RoleCollection { get; private set; }

        [Required]
        public string SelectedRole { get; set; }

        public TaskCommand ShowView { get; private set; }

        private bool OnShowViewCanExecute()
        {
            return !string.IsNullOrEmpty(SelectedRole);
        }

        private async Task OnShowViewExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<ExampleViewModel>();
        }

        private void OnSelectedRoleChanged()
        {
            // Dirty cast, normally this would be done via clean interfaces
            ((Catel.Examples.Authentication.AuthenticationProvider) _authenticationProvider).Role = SelectedRole;
        }
    }
}
