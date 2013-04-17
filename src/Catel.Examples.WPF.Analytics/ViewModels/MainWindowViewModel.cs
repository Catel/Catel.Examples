namespace Catel.Examples.WPF.Analytics.ViewModels
{
    using System.Threading;
    using Auditors;
    using Catel.MVVM;
    using MVVM.Auditing;
    using MVVM.Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            FirstCommand = new Command(OnFirstCommandExecute);
            SecondCommand = new Command(OnSecondCommandExecute);
            ShowWindow = new Command(OnShowWindowExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Google analytics example"; } }
        #endregion

        #region Commands
        /// <summary>
        /// Gets the FirstCommand command.
        /// </summary>
        public Command FirstCommand { get; private set; }

        /// <summary>
        /// Method to invoke when the FirstCommand command is executed.
        /// </summary>
        private void OnFirstCommandExecute()
        {
            var pleaseWaitService = GetService<IPleaseWaitService>();
            pleaseWaitService.Show(() => Thread.Sleep(500), "Tracking 'FirstCommand' automatically");
        }

        /// <summary>
        /// Gets the SecondCommand command.
        /// </summary>
        public Command SecondCommand { get; private set; }

        /// <summary>
        /// Method to invoke when the SecondCommand command is executed.
        /// </summary>
        private void OnSecondCommandExecute()
        {
            var pleaseWaitService = GetService<IPleaseWaitService>();
            pleaseWaitService.Show(() => Thread.Sleep(500), "Tracking 'SecondCommand' automatically");
        }

        /// <summary>
        /// Gets the ShowWindow command.
        /// </summary>
        public Command ShowWindow { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowWindow command is executed.
        /// </summary>
        private void OnShowWindowExecute()
        {
            // TODO: Handle command logic here
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the view model. Normally the initialization is done in the constructor, but sometimes this must be delayed
        /// to a state where the associated UI element (user control, window, ...) is actually loaded.
        /// <para/>
        /// This method is called as soon as the associated UI element is loaded.
        /// </summary>
        /// <remarks>
        /// It's not recommended to implement the initialization of properties in this method. The initialization of properties
        /// should be done in the constructor. This method should be used to start the retrieval of data from a web service or something
        /// similar.
        /// <para/>
        /// During unit tests, it is recommended to manually call this method because there is no external container calling this method.
        /// </remarks>
        protected override void Initialize()
        {
            var vm = new ProvideAnalyticsViewModel();

            var uiVisualizerService = GetService<IUIVisualizerService>();
            if (uiVisualizerService.ShowDialog(vm) ?? false)
            {
                AuditingManager.RegisterAuditor(new GoogleAnalytics(vm.ApiKey, "Catel Analytics Example"));
            }
            else
            {
                var messageService = GetService<IMessageService>();
                messageService.ShowError("Cannot provide analytics when no API is provided");
            }
        }
        #endregion
    }
}
