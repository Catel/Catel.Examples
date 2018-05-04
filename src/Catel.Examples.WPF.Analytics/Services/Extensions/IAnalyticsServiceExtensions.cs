// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnalyticsServiceExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2018 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Analytics.Services
{
    using System;
    using System.Threading.Tasks;

    public static class IAnalyticsServiceExtensions
    {
        #region Methods
        public static async Task ExecuteAndTrackAsync(this IAnalyticsService service, Func<Task> func, string category,
            string variable)
        {
            Argument.IsNotNull("service", service);

            var startTime = DateTime.Now;

            await func();

#pragma warning disable 4014
            service.SendTimingAsync(DateTime.Now.Subtract(startTime), category, variable);
#pragma warning restore 4014
        }

        public static async Task<T> ExecuteAndTrackWithResultAsync<T>(this IAnalyticsService service, Func<Task<T>> func, string category,
            string variable)
        {
            Argument.IsNotNull("service", service);

            var startTime = DateTime.Now;

            var result = await func();

#pragma warning disable 4014
            service.SendTimingAsync(DateTime.Now.Subtract(startTime), category, variable);
#pragma warning restore 4014

            return result;
        }

        public static Task SendViewModelCreatedAsync(this IAnalyticsService googleAnalytics, string viewModel)
        {
            Argument.IsNotNull("googleAnalytics", googleAnalytics);

            return googleAnalytics.SendEventAsync("ViewModels", string.Format("{0}.Created", viewModel), viewModel);
        }

        public static async Task SendViewModelClosedAsync(this IAnalyticsService googleAnalytics, string viewModel, TimeSpan duration)
        {
            Argument.IsNotNull("googleAnalytics", googleAnalytics);

            await googleAnalytics.SendEventAsync("ViewModels", string.Format("{0}.Closed", viewModel), viewModel);
            await googleAnalytics.SendTimingAsync(duration, "ViewModels", viewModel);
        }

        public static Task SendCommandAsync(this IAnalyticsService googleAnalytics, string viewModelName, string commandName)
        {
            Argument.IsNotNull("googleAnalytics", googleAnalytics);

            var eventName = viewModelName;
            if (!string.IsNullOrEmpty(eventName))
            {
                eventName += ".";
            }
            else
            {
                eventName = string.Empty;
            }

            eventName += commandName;

            return googleAnalytics.SendEventAsync("Commands", eventName);
        }
        #endregion
    }
}