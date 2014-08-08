namespace Catel.Examples.AdvancedDemo
{
    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;
    using IoC;
    using Logging;
    using MVVM;
    using Microsoft.Practices.Unity;
    using Views;

    /// <summary>
    /// Main application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            Startup += OnApplicationStartup;
            Exit += OnApplicationExit;
            UnhandledException += OnApplicationUnhandledException;

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Startup event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.StartupEventArgs"/> instance containing the event data.</param>
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            Catel.Windows.StyleHelper.CreateStyleForwardersForDefaultStyles();

#if DEBUG
            var debugListener = new DebugLogListener();
            debugListener.IsDebugEnabled = false;

            LogManager.AddListener(debugListener);
#endif

            var serviceLocator = ServiceLocator.Default;

            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.NamingConventions.Add("[UP].Views.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]Window");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]Window");

            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.NamingConventions.Add("Catel.Examples.AdvancedDemo.ViewModels.[VW]ViewModel");

            RootVisual = new MainPage();
        }

        /// <summary>
        /// Handles the Exit event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the UnhandledException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.ApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void OnApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        /// <summary>
        /// Reports the error to DOM.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.ApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}