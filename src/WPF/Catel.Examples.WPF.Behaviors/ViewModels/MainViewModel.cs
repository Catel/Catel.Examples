// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Behaviors.ViewModels
{
    using System;
    using System.Windows.Threading;
    using Data;
    using IoC;
    using MVVM;
    using Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Constants
        /// <summary>
        /// Register the IsPleaseWaitIndeterminate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData IsPleaseWaitIntermediateProperty = RegisterProperty("IsPleaseWaitIndeterminate", typeof(bool), true);
        #endregion

        #region Fields
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;

            ShowWindowLogicInViewBase = new Command(OnShowWindowLogicInViewBaseExecute);
            ShowWindowLogicInBehavior = new Command(OnShowWindowLogicInBehaviorExecute);

            ShowNestedUserControlsLogicInViewBase = new Command(OnShowNestedUserControlsLogicInViewBaseExecute);
            ShowNestedUserControlsLogicInBehavior = new Command(OnShowNestedUserControlsLogicInBehaviorExecute);

            ShowPleaseWaitWindowViaServiceLocator = new Command(OnShowPleaseWaitWindowViaServiceLocatorExecute);

            ShowWindowWithBehaviors = new Command(OnShowWindowWithBehaviorsExecute);
            ShowThrottling = new Command(OnShowThrottlingExecute);
        }
        #endregion
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Advanced Catel Demo"; }
        }

        /// <summary>
        /// Gets the <see cref="IPleaseWaitService"/> via the Catel <see cref="ServiceLocator"/>.
        /// </summary>
        /// <value>The <see cref="IPleaseWaitService"/> via the Catel <see cref="ServiceLocator"/>.</value>
        public IPleaseWaitService PleaseWaitServiceViaServiceLocator
        {
            get { return _pleaseWaitService; }
        }

        /// <summary>
        /// Gets or sets whether the please wait windows is intermediate.
        /// </summary>
        public bool IsPleaseWaitIndeterminate
        {
            get { return GetValue<bool>(IsPleaseWaitIntermediateProperty); }
            set { SetValue(IsPleaseWaitIntermediateProperty, value); }
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

        #region Variables
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

            var typeFactory = TypeFactory.Default;
            var vm = typeFactory.CreateInstance<DemoWindowViewModel>();

            _uiVisualizerService.ShowDialog(vm);
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

            var typeFactory = TypeFactory.Default;
            var vm = typeFactory.CreateInstance<DemoWindowViewModel>();

            _uiVisualizerService.ShowDialog(vm);
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

            var typeFactory = TypeFactory.Default;
            var vm = typeFactory.CreateInstance<NestedUserControlsWindowViewModel>();

            _uiVisualizerService.ShowDialog(vm);
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

            var typeFactory = TypeFactory.Default;
            var vm = typeFactory.CreateInstance<NestedUserControlsWindowViewModel>();

            _uiVisualizerService.ShowDialog(vm);
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
        /// Gets the ShowWindowWithBehaviors command.
        /// </summary>
        public Command ShowWindowWithBehaviors { get; private set; }

        /// <summary>
        /// Method to invoke when the ShowWindowWithBehaviors command is executed.
        /// </summary>
        private void OnShowWindowWithBehaviorsExecute()
        {
            var typeFactory = TypeFactory.Default;
            var viewModel = typeFactory.CreateInstance<BehaviorsWindowViewModel>();

            _uiVisualizerService.ShowDialog(viewModel);
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
    }
}