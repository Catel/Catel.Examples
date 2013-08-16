namespace Catel.Examples.WP7.Sensors.ViewModels
{
    using System.Collections.Generic;
    using MVVM;
    using MVVM.Services;

    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel(INavigationService navigationService)
            : base()
        {
            _navigationService = navigationService;

            StartTestSensors = new Command<object>(OnStartTestSensorsExecute);
            StartRealSensors = new Command<object>(OnStartRealSensorsExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Sensors demo"; }
        }

        #region Models
        // TODO: Register models with the vmpropmodel codesnippet
        #endregion

        #region View model
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        #endregion

        #endregion

        #region Commands
        /// <summary>
        /// Gets the StartTestSensors command.
        /// </summary>
        public Command<object> StartTestSensors { get; private set; }

        /// <summary>
        /// Method to invoke when the StartTestSensors command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnStartTestSensorsExecute(object parameter)
        {
            StartSensors(true);
        }

        /// <summary>
        /// Gets the StartRealSensors command.
        /// </summary>
        public Command<object> StartRealSensors { get; private set; }

        /// <summary>
        /// Method to invoke when the StartRealSensors command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnStartRealSensorsExecute(object parameter)
        {
            StartSensors(false);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the sensors.
        /// </summary>
        /// <param name="testMode">if set to <c>true</c>, the test implementation will be started.</param>
        private void StartSensors(bool testMode)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("testmode", testMode);

            _navigationService.Navigate(typeof (SensorsViewModel), parameters);
        }
        #endregion
    }
}