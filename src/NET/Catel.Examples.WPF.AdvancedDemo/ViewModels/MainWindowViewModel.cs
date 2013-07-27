namespace Catel.Examples.AdvancedDemo.ViewModels
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows.Threading;
    using Data;
    using IoC;
    using MVVM;
    using MVVM.Services;
    using Microsoft.Practices.Unity;

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
        public MainWindowViewModel()
        {
            _uiVisualizerService = ServiceLocator.ResolveType<IUIVisualizerService>();

            ShowWindowLogicInViewBase = new Command(OnShowWindowLogicInViewBaseExecute);
            ShowWindowLogicInBehavior = new Command(OnShowWindowLogicInBehaviorExecute);

            ShowNestedUserControlsLogicInViewBase = new Command(OnShowNestedUserControlsLogicInViewBaseExecute);
            ShowNestedUserControlsLogicInBehavior = new Command(OnShowNestedUserControlsLogicInBehaviorExecute);

            ShowPleaseWaitWindowViaServiceLocator = new Command(OnShowPleaseWaitWindowViaServiceLocatorExecute);
            ShowPleaseWaitWindowViaMEF = new Command(OnShowPleaseWaitWindowViaMEFExecute);
            ShowPleaseWaitWindowViaUnity = new Command(OnShowPleaseWaitWindowViaUnityExecute);

            ShowWindowWithBehaviors = new Command(OnShowWindowWithBehaviorsExecute);
            ShowThrottling = new Command(OnShowThrottlingExecute);

            // The external containers such as Unity and MEF are registered in App.xaml
            IoCHelper.MefContainer.SatisfyImportsOnce(this);
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
        public IPleaseWaitService PleaseWaitServiceViaServiceLocator { get { return GetService<IPleaseWaitService>(); } }

        /// <summary>
        /// Gets or sets the <see cref="IPleaseWaitService"/> via MEF.
        /// </summary>
        /// <value>The <see cref="IPleaseWaitService"/> via MEF.</value>
        [Import]
        public IPleaseWaitService PleaseWaitServiceViaMEF { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IPleaseWaitService"/> via Unity.
        /// </summary>
        /// <value>The <see cref="IPleaseWaitService"/> via Unity.</value>
        public IPleaseWaitService PleaseWaitServiceViaUnity { get { return IoCHelper.UnityContainer.Resolve<IPleaseWaitService>(); } }

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
        /// Gets the ShowWindowLogicInViewBase command.
        /// </summary>
        public Command ShowWindowLogicInViewBase { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowWindowLogicInViewBase command is executed.
        /// </summary>
        private void OnShowWindowLogicInViewBaseExecute()
        {
            _uiVisualizerService.Unregister(typeof(DemoWindowViewModel));
            _uiVisualizerService.Register(typeof(DemoWindowViewModel), typeof(Views.LogicInViewBase.DemoWindow));
            _uiVisualizerService.ShowDialog(new DemoWindowViewModel());
        }

        /// <summary>
        /// Gets the ShowWindowLogicInBehavior command.
        /// </summary>
        public Command ShowWindowLogicInBehavior { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowWindowLogicInBehavior command is executed.
        /// </summary>
        private void OnShowWindowLogicInBehaviorExecute()
        {
            _uiVisualizerService.Unregister(typeof(DemoWindowViewModel));
            _uiVisualizerService.Register(typeof(DemoWindowViewModel), typeof(Views.LogicInBehavior.DemoWindow));
            _uiVisualizerService.ShowDialog(new DemoWindowViewModel());
        }

        /// <summary>
        /// Gets the ShowNestedUserControlsLogicInViewBase command.
        /// </summary>
        public Command ShowNestedUserControlsLogicInViewBase { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowNestedUserControlsLogicInViewBase command is executed.
        /// </summary>
        private void OnShowNestedUserControlsLogicInViewBaseExecute()
        {
            _uiVisualizerService.Unregister(typeof(NestedUserControlsWindowViewModel));
            _uiVisualizerService.Register(typeof(NestedUserControlsWindowViewModel), typeof(Views.LogicInViewBase.NestedUserControlsWindow));
            _uiVisualizerService.ShowDialog(new NestedUserControlsWindowViewModel());
        }

        /// <summary>
        /// Gets the ShowNestedUserControlsLogicInBehavior command.
        /// </summary>
        public Command ShowNestedUserControlsLogicInBehavior { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowNestedUserControlsLogicInBehavior command is executed.
        /// </summary>
        private void OnShowNestedUserControlsLogicInBehaviorExecute()
        {
            _uiVisualizerService.Unregister(typeof(NestedUserControlsWindowViewModel));
            _uiVisualizerService.Register(typeof(NestedUserControlsWindowViewModel), typeof(Views.LogicInBehavior.NestedUserControlsWindow));
            _uiVisualizerService.ShowDialog(new NestedUserControlsWindowViewModel());
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

        /// <summary>
        /// Gets the ShowPleaseWaitWindowViaMEF command.
        /// </summary>
        public Command ShowPleaseWaitWindowViaMEF { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowPleaseWaitWindowViaMEF command is executed.
        /// </summary>
        private void OnShowPleaseWaitWindowViaMEFExecute()
        {
            ShowPleaseWaitWindow(PleaseWaitServiceViaMEF, "MEF works");
        }

        /// <summary>
        /// Gets the ShowPleaseWaitWindowViaUnity command.
        /// </summary>
        public Command ShowPleaseWaitWindowViaUnity { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowPleaseWaitWindowViaUnity command is executed.
        /// </summary>
        private void OnShowPleaseWaitWindowViaUnityExecute()
        {
            ShowPleaseWaitWindow(PleaseWaitServiceViaUnity, "Unity works");
        }

        /// <summary>
        /// Gets the ShowWindowWithBehaviors command.
        /// </summary>
        public Command ShowWindowWithBehaviors { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowWindowWithBehaviors command is executed.
        /// </summary>
        private void OnShowWindowWithBehaviorsExecute()
        {
            _uiVisualizerService.ShowDialog(new BehaviorsWindowViewModel());
        }

        /// <summary>
        /// Gets the ShowThrottling command.
        /// </summary>
        public Command ShowThrottling { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowThrottling command is executed.
        /// </summary>
        private void OnShowThrottlingExecute()
        {
            _uiVisualizerService.ShowDialog(new ThrottlingViewModel());
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
