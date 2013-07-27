// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.WPF.MvvmCommunicationStyles.ViewModels
{
    using Examples.MvvmCommunicationStyles.ViewModels;
    using MVVM;
    using MVVM.Services;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;

            InterestedInExample = new Command(OnInterestedInExampleExecute);
            MessageMediatorExample = new Command(OnMessageMediatorExampleExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public override string Title
        {
            get { return "MVVM communication styles"; }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Gets the InterestedInExample command.
        /// </summary>
        public Command InterestedInExample { get; private set; }

        /// <summary>
        /// Method to invoke when the InterestedInExample command is executed.
        /// </summary>
        private void OnInterestedInExampleExecute()
        {
            var vm = new InterestedInViewModel();
            _uiVisualizerService.ShowDialog(vm);
        }

        /// <summary>
        /// Gets the MessageMediatorExample command.
        /// </summary>
        public Command MessageMediatorExample { get; private set; }

        /// <summary>
        /// Method to invoke when the MessageMediatorExample command is executed.
        /// </summary>
        private void OnMessageMediatorExampleExecute()
        {
            var vm = new MessageMediatorViewModel();
            _uiVisualizerService.ShowDialog(vm);
        }
        #endregion
    }
}