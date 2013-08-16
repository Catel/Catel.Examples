namespace Catel.Examples.WPF.Authentication.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using Catel.MVVM;
    using Data;
    using MVVM.Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IAuthenticationProvider _authenticationProvider;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IAuthenticationProvider authenticationProvider)
        {
            _uiVisualizerService = uiVisualizerService;
            _authenticationProvider = authenticationProvider;

            RoleCollection = new ObservableCollection<string>(new [] { "Read-only", "Administrator" });

            ShowView = new Command(OnShowViewExecute, OnShowViewCanExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Authentication example"; } }

        /// <summary>
        /// Gets or sets the role collection.
        /// </summary>
        public ObservableCollection<string> RoleCollection
        {
            get { return GetValue<ObservableCollection<string>>(RoleCollectionProperty); }
            set { SetValue(RoleCollectionProperty, value); }
        }

        /// <summary>
        /// Register the RoleCollection property so it is known in the class.
        /// </summary>
        public static readonly PropertyData RoleCollectionProperty = RegisterProperty("RoleCollection", typeof(ObservableCollection<string>));

        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        [Required]
        public string SelectedRole
        {
            get { return GetValue<string>(SelectedRoleProperty); }
            set { SetValue(SelectedRoleProperty, value); }
        }

        /// <summary>
        /// Register the SelectedRole property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedRoleProperty = RegisterProperty("SelectedRole", typeof(string), null, 
            (sender, e) => ((MainWindowViewModel)sender).OnSelectedRoleChanged());
        #endregion

        #region Commands
        /// <summary>
        /// Gets the ShowView command.
        /// </summary>
        public Command ShowView { get; private set; }

        /// <summary>
        /// Method to check whether the ShowView command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnShowViewCanExecute()
        {
            return !string.IsNullOrEmpty(SelectedRole);
        }

        /// <summary>
        /// Method to invoke when the ShowView command is executed.
        /// </summary>
        private void OnShowViewExecute()
        {
            _uiVisualizerService.ShowDialog(new ExampleViewModel());
        }
        #endregion

        #region Methods
        private void OnSelectedRoleChanged()
        {
            // Dirty cast, normally this would be done via clean interfaces
            ((AuthenticationProvider)_authenticationProvider).Role = SelectedRole;
        }
        #endregion
    }
}
