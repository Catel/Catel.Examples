// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleAnalytics.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Analytics.Auditors
{
    using B4.AppLibrary;
    using MVVM;
    using MVVM.Auditing;

    /// <summary>
    ///   Google Analytics auditor.
    /// </summary>
    public class GoogleAnalytics : AuditorBase
    {
        #region Fields
        private readonly ApplicationTracker _appTracker;
        #endregion

        #region Constructors
        public GoogleAnalytics(string apiKey, string applicationName)
        {
            Argument.IsNotNull("apiKey", apiKey);
            Argument.IsNotNull("applicationName", applicationName);

            _appTracker = new ApplicationTracker(apiKey, applicationName);
            _appTracker.StartSession();
        }
        #endregion

        #region Methods
        public override void OnCommandExecuted(IViewModel viewModel, string commandName, ICatelCommand command, object commandParameter)
        {
            _appTracker.TrackEvent(ApplicationTrackerCategories.Command, string.Format("{0}.{1}", viewModel.GetType().Name, commandName));
        }

        public override void OnViewModelCreated(IViewModel viewModel)
        {
            var viewModelTypeName = viewModel.GetType().Name;

            _appTracker.TrackPageView(viewModelTypeName);

            _appTracker.TrackCustomEvent("ViewModel.Created", viewModelTypeName);
        }

        public override void OnViewModelCanceled(IViewModel viewModel)
        {
            _appTracker.TrackCustomEvent("ViewModel.Canceled", viewModel.GetType().Name);
        }

        public override void OnViewModelSaved(IViewModel viewModel)
        {
            _appTracker.TrackCustomEvent("ViewModel.Saved", viewModel.GetType().Name);
        }

        public override void OnViewModelClosed(IViewModel viewModel)
        {
            _appTracker.TrackCustomEvent("ViewModel.Closed", viewModel.GetType().Name);
        }
        #endregion
    }
}