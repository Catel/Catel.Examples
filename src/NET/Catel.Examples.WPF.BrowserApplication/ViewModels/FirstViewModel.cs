namespace Catel.Examples.WPF.BrowserApplication.ViewModels
{
    using System.Collections.Generic;
    using Data;
    using MVVM;
    using Services;

    /// <summary>
    /// First view model.
    /// </summary>
    public class FirstViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstViewModel"/> class.
        /// </summary>
        public FirstViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToOtherPage = new Command<object>(OnNavigateToOtherPageExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "First view model"; } }

        /// <summary>
        /// Gets or sets the argument received.
        /// </summary>
        public string ArgumentReceived
        {
            get { return GetValue<string>(ArgumentReceivedProperty); }
            set { SetValue(ArgumentReceivedProperty, value); }
        }

        /// <summary>
        /// Register the ArgumentReceived property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ArgumentReceivedProperty = RegisterProperty("ArgumentReceived", typeof(string));

        /// <summary>
        /// Gets or sets the argument to set.
        /// </summary>
        public string ArgumentToSet
        {
            get { return GetValue<string>(ArgumentToSetProperty); }
            set { SetValue(ArgumentToSetProperty, value); }
        }

        /// <summary>
        /// Register the ArgumentToSet property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ArgumentToSetProperty = RegisterProperty("ArgumentToSet", typeof(string));
        #endregion

        #region Commands
        /// <summary>
        /// Gets the NavigateToOtherPage command.
        /// </summary>
        public Command<object> NavigateToOtherPage { get; private set; }

        /// <summary>
        /// Method to invoke when the NavigateToOtherPage command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnNavigateToOtherPageExecute(object parameter)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Argument", ArgumentToSet);

            _navigationService.Navigate<SecondViewModel>(parameters);
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
            if (NavigationContext.Values.ContainsKey("Argument"))
            {
                ArgumentReceived = NavigationContext.Values["Argument"] as string;
            }
        }
        #endregion
    }
}
