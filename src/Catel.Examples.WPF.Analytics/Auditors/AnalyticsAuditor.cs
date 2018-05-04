// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyticsAuditor.cs" company="Catel development team">
//   Copyright (c) 2008 - 2018 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Analytics.Auditors
{
    using System;
    using System.Collections.Generic;
    using MVVM;
    using MVVM.Auditing;
    using Services;

    public class AnalyticsAuditor : AuditorBase
    {
        #region Fields
        private readonly IAnalyticsService _analyticsService;

        private readonly Dictionary<int, DateTime> _viewModelCreationTimes = new Dictionary<int, DateTime>();
        #endregion

        #region Constructors
        public AnalyticsAuditor(IAnalyticsService analyticsService)
        {
            Argument.IsNotNull(() => analyticsService);

            _analyticsService = analyticsService;
        }
        #endregion

        #region Methods
        public override void OnCommandExecuted(IViewModel viewModel, string commandName, ICatelCommand command, object commandParameter)
        {
            base.OnCommandExecuted(viewModel, commandName, command, commandParameter);

            var viewModelName = viewModel != null ? viewModel.GetType().Name : string.Empty;

            _analyticsService.SendCommandAsync(viewModelName, commandName);
        }

        public override void OnViewModelCreated(IViewModel viewModel)
        {
            base.OnViewModelCreated(viewModel);

            _viewModelCreationTimes[viewModel.UniqueIdentifier] = DateTime.Now;

            _analyticsService.SendViewModelCreatedAsync(viewModel.GetType().FullName);
        }

        public override void OnViewModelClosed(IViewModel viewModel)
        {
            base.OnViewModelClosed(viewModel);

            if (_viewModelCreationTimes.ContainsKey(viewModel.UniqueIdentifier))
            {
                var lifetime = DateTime.Now.Subtract(_viewModelCreationTimes[viewModel.UniqueIdentifier]);

#pragma warning disable 4014
                _analyticsService.SendViewModelClosedAsync(viewModel.GetType().FullName, lifetime);
#pragma warning restore 4014
            }
        }
        #endregion
    }
}