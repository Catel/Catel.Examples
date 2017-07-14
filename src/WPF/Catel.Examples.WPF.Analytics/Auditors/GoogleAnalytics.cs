namespace Catel.Examples.WPF.Analytics.Auditors
{
    using System;
    using B4.AppLibrary;
    using MVVM;
    using MVVM.Auditing;

    /// <summary>
    ///   Google Analytics auditor.
    /// </summary>
    public class GoogleAnalytics : AuditorBase
    {
        private readonly ApplicationTracker _appTracker;

        public GoogleAnalytics(string apiKey, string applicationName)
        {
            Argument.IsNotNull("apiKey", apiKey);
            Argument.IsNotNull("applicationName", applicationName);

            _appTracker = new ApplicationTracker(apiKey, applicationName);
            _appTracker.StartSession();
        }

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
    }
}