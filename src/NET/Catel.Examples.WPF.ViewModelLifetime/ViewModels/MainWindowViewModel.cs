namespace Catel.Examples.WPF.ViewModelLifetime.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Threading;
    using Catel.MVVM;
    using Catel.Services;
    using Data;
    using Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly ITabService _tabService;

        #region Variables
        private DispatcherTimer _timer = new DispatcherTimer();
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, ITabService tabService)
        {
            _uiVisualizerService = uiVisualizerService;
            _tabService = tabService;

            _timer.Tick += OnTimerTick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();

            AddTab = new Command(OnAddTabExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "View model lifetime demo"; } }

        /// <summary>
        /// Gets or sets the number of live view model instances.
        /// </summary>
        public int LiveViewModelCount
        {
            get { return GetValue<int>(LiveViewModelCountProperty); }
            set { SetValue(LiveViewModelCountProperty, value); }
        }

        /// <summary>
        /// Register the LiveViewModelCount property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LiveViewModelCountProperty = RegisterProperty("LiveViewModelCount", typeof(int));
        #endregion

        #region Commands
        /// <summary>
        /// Gets the AddTab command.
        /// </summary>
        public Command AddTab { get; private set; }

        /// <summary>
        /// Method to invoke when the AddTab command is executed.
        /// </summary>
        private async void OnAddTabExecute()
        {
            var vm = new CreateTabWindowViewModel();
            if (await _uiVisualizerService.ShowDialog(vm) ?? false)
            {
                _tabService.AddTab(vm.CloseWhenUnloaded);
            }
        }
        #endregion

        #region Methods
        private void OnTimerTick(object sender, EventArgs e)
        {
            LiveViewModelCount = ViewModelManager.ActiveViewModels.Count();
        }
        #endregion
    }
}
