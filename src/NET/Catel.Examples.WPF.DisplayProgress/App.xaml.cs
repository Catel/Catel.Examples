namespace Catel.Examples.DisplayProgress
{
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Methods

        /// <summary>
        /// The application_ startup.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new Boot().Run(true);
        }

        #endregion
    }
}