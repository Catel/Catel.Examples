namespace Catel.Examples.WIN80.Advanced.ViewModels
{
    using System;
    using Data;
    using IoC;
    using MVVM;
    using MVVM.Services;
    using global::Windows.UI.Xaml;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly INavigationService _navigationService;

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel(IPleaseWaitService pleaseWaitService, INavigationService navigationService)
        {
            _pleaseWaitService = pleaseWaitService;
            _navigationService = navigationService;

            ShowNestedUserControls = new Command(OnShowNestedUserControlsLogicInViewBaseExecute);

            ShowPleaseWaitWindowViaServiceLocator = new Command(OnShowPleaseWaitWindowViaServiceLocatorExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Advanced Catel Demo"; } }

        /// <summary>
        /// Gets the <see cref="IPleaseWaitService"/> via the Catel <see cref="ServiceLocator"/>.
        /// </summary>
        /// <value>The <see cref="IPleaseWaitService"/> via the Catel <see cref="ServiceLocator"/>.</value>
        public IPleaseWaitService PleaseWaitServiceViaServiceLocator { get { return _pleaseWaitService; } }

        /// <summary>
        /// Gets or sets whether the please wait windows is intermediate.
        /// </summary>
        public bool IsPleaseWaitIndeterminate
        {
            get { return GetValue<bool>(IsPleaseWaitIntermediateProperty); }
            set { SetValue(IsPleaseWaitIntermediateProperty, value); }
        }

        /// <summary>
        /// Register the IsPleaseWaitIndeterminate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IsPleaseWaitIntermediateProperty = RegisterProperty("IsPleaseWaitIndeterminate", typeof(bool), true);
        #endregion

        #region Commands
        /// <summary>
        /// Gets the ShowNestedUserControlsLogicInViewBase command.
        /// </summary>
        public Command ShowNestedUserControls { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowNestedUserControlsLogicInViewBase command is executed.
        /// </summary>
        private void OnShowNestedUserControlsLogicInViewBaseExecute()
        {
            _navigationService.Navigate<NestedUserControlsViewModel>();
        }

        /// <summary>
        /// Gets the ShowPleaseWaitWindowViaServiceLocator command.
        /// </summary>
        public Command ShowPleaseWaitWindowViaServiceLocator { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowPleaseWaitWindowViaServiceLocator command is executed.
        /// </summary>
        private void OnShowPleaseWaitWindowViaServiceLocatorExecute()
        {
            ShowPleaseWaitWindow(PleaseWaitServiceViaServiceLocator, "ServiceLocator works");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Shows the please wait window using the specific <paramref name="service"/>.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="status">The status.</param>
        private void ShowPleaseWaitWindow(IPleaseWaitService service, string status)
        {
            string determinateFormatString = "Updating item {0} of {1} (" + status + ")";

            const int CounterMax = 25;
            int counter = 0;
            bool isIndeterminate = IsPleaseWaitIndeterminate;

            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Tick += (sender, e) =>
                                        {
                                            bool exit = false;

                                            counter++;

                                            if (counter >= CounterMax + 1)
                                            {
                                                exit = true;
                                            }
                                            else if (!isIndeterminate)
                                            {
                                                service.UpdateStatus(counter, CounterMax, determinateFormatString);
                                            }

                                            if (exit)
                                            {
                                                dispatcherTimer.Stop();
                                                service.Hide();
                                            }
                                        };

            if (isIndeterminate)
            {
                service.Show(status);
            }
            else
            {
                service.UpdateStatus(1, CounterMax, determinateFormatString);
            }

            dispatcherTimer.Start();
        }
        #endregion
    }
}
