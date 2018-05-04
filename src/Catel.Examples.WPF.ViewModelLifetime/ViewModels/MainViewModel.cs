// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.ViewModelLifetime.ViewModels
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using Catel.Services;
    using Data;
    using MVVM;
    using Services;

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly ITabService _tabService;
        private readonly IUIVisualizerService _uiVisualizerService;

        private readonly DispatcherTimer _timer = new DispatcherTimer();
        #endregion

        #region Constructors
        public MainViewModel(IUIVisualizerService uiVisualizerService, ITabService tabService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => tabService);

            _uiVisualizerService = uiVisualizerService;
            _tabService = tabService;

            _timer.Tick += OnTimerTick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            _timer.Start();

            AddTab = new TaskCommand(OnAddTabExecuteAsync);

            Title = "View model lifetime demo";
        }
        #endregion

        #region Properties
        public int LiveViewModelCount { get; set; }
        #endregion

        #region Methods
        private void OnTimerTick(object sender, EventArgs e)
        {
            LiveViewModelCount = ViewModelManager.ActiveViewModels.Count();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Gets the AddTab command.
        /// </summary>
        public TaskCommand AddTab { get; private set; }

        /// <summary>
        /// Method to invoke when the AddTab command is executed.
        /// </summary>
        private async Task OnAddTabExecuteAsync()
        {
            var vm = new CreateTabWindowViewModel();
            if (await _uiVisualizerService.ShowDialogAsync(vm) ?? false)
            {
                _tabService.AddTab(vm.CloseWhenUnloaded);
            }
        }
        #endregion
    }
}