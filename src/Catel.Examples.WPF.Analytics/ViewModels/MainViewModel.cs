// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Analytics.ViewModels
{
    using System.Threading;
    using System.Threading.Tasks;
    using Auditors;
    using Catel.Services;
    using MVVM;
    using MVVM.Auditing;
    using Services;

    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAnalyticsService _analyticsService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainWindowViewModel(IPleaseWaitService pleaseWaitService, IUIVisualizerService uiVisualizerService, 
            IMessageService messageService, IViewModelFactory viewModelFactory, IAnalyticsService analyticsService)
        {
            Argument.IsNotNull(() => pleaseWaitService);
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => messageService);
            Argument.IsNotNull(() => viewModelFactory);
            Argument.IsNotNull(() => analyticsService);

            _pleaseWaitService = pleaseWaitService;
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;
            _viewModelFactory = viewModelFactory;
            _analyticsService = analyticsService;

            FirstCommand = new Command(OnFirstCommandExecute);
            SecondCommand = new Command(OnSecondCommandExecute);
            ShowWindow = new Command(OnShowWindowExecute);

            Title = "Analytics example";
        }
        #endregion

        #region Commands
        public Command FirstCommand { get; private set; }

        private void OnFirstCommandExecute()
        {
            _pleaseWaitService.Show(() => Thread.Sleep(500), "Tracking 'FirstCommand' automatically");
        }

        public Command SecondCommand { get; private set; }

        private void OnSecondCommandExecute()
        {
            _pleaseWaitService.Show(() => Thread.Sleep(500), "Tracking 'SecondCommand' automatically");
        }

        public Command ShowWindow { get; private set; }

        private void OnShowWindowExecute()
        {
            // TODO: Handle command logic here
        }
        #endregion

        #region Methods
        protected override async Task InitializeAsync()
        {
            var vm = _viewModelFactory.CreateViewModel<ProvideAnalyticsViewModel>(null);

            if (await _uiVisualizerService.ShowDialogAsync(vm) ?? false)
            {
                _analyticsService.AccountId = vm.ApiKey;
            }
            else
            {
                await _messageService.ShowErrorAsync("Cannot provide analytics when no API is provided");
            }
        }
        #endregion
    }
}