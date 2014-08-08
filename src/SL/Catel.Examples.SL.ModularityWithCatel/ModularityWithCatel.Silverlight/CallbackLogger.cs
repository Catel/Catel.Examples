//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================

namespace ModularityWithCatel.Silverlight
{
    using System;
    using System.Collections.Generic;

    using Catel.Logging;

    using Microsoft.Practices.Prism.Logging;

    /// <summary>
    /// A logger that holds on to log entries until a callback delegate is set, then plays back log entries and sends new log entries.
    /// </summary>
    /// <summary>
    /// A logger that holds on to log entries until a callback delegate is set, then plays back log entries and sends new log entries.
    /// </summary>
    public class CallbackLogger : LogListenerBase
    {
        #region Fields

        /// <summary>
        /// The saved logs.
        /// </summary>
        private readonly Queue<Tuple<string, Category>> savedLogs = new Queue<Tuple<string, Category>>();

        /// <summary>
        /// The callback.
        /// </summary>
        private Action<string, Category> callback;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the callback to receive logs.
        /// </summary>
        /// <value>An Action&lt;string, Category, Priority&gt; callback.</value>
        public Action<string, Category> Callback
        {
            get { return callback; }
            set { callback = value; }
        }

        #endregion

        #region Methods
        public void Log(string message, Category category)
        {
            if (Callback != null)
            {
                Callback(message, category);
            }
            else
            {
                savedLogs.Enqueue(new Tuple<string, Category>(message, category));
            }
        }

        public void ReplaySavedLogs()
        {
            if (Callback != null)
            {
                while (savedLogs.Count > 0)
                {
                    var log = savedLogs.Dequeue();
                    Callback(log.Item1, log.Item2);
                }
            }
        }

        protected override void Debug(ILog log, string message, object extraData, DateTime time)
        {
            Log(message, Category.Debug);
        }

        protected override void Info(ILog log, string message, object extraData, DateTime time)
        {
            Log(message, Category.Info);
        }

        protected override void Warning(ILog log, string message, object extraData, DateTime time)
        {
            Log(message, Category.Warn);
        }

        protected override void Error(ILog log, string message, object extraData, DateTime time)
        {
            Log(message, Category.Exception);
        }

        #endregion
    }
}