namespace Catel.Examples.SL.NavigationApplication.ViewModels
{
    using System.Collections.Generic;
    using Data;
    using MVVM;
    using MVVM.Services;

    /// <summary>
    /// About view model.
    /// </summary>
    public class AboutViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        public AboutViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToHomeViaViewModel = new Command<object>(OnNavigateToHomeViaViewModelExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "About"; } }

        /// <summary>
        /// Gets or sets the navigation data.
        /// </summary>
        public string NavigationData
        {
            get { return GetValue<string>(NavigationDataProperty); }
            set { SetValue(NavigationDataProperty, value); }
        }

        /// <summary>
        /// Register the NavigationData property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NavigationDataProperty = RegisterProperty("NavigationData", typeof(string));
        #endregion

        #region Commands
        /// <summary>
        /// Gets the NavigateToHomeViaViewModel command.
        /// </summary>
        public Command<object> NavigateToHomeViaViewModel { get; private set; }

        /// <summary>
        /// Method to invoke when the NavigateToHomeViaViewModel command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnNavigateToHomeViaViewModelExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Data", "navigated from about");

            _navigationService.Navigate<HomeViewModel>(parameters);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the navigation has completed.
        /// </summary>
        /// <remarks>
        /// This should of course be a cleaner solution, but there is no other way to let a view-model
        /// know that navigation has completed. Another option is injection, but this would require every
        /// view-model for Windows Phone 7 to accept only the navigation context, which has actually nothing
        /// to do with the logic.
        /// <para/>
        /// It is also possible to use the <see cref="NavigationCompleted"/> event.
        /// </remarks>
        protected override void OnNavigationCompleted()
        {
            NavigationData = string.Empty;
            if (NavigationContext.ContainsKey("Data"))
            {
                NavigationData = NavigationContext["Data"] as string;
            }
        }
        #endregion
    }
}
