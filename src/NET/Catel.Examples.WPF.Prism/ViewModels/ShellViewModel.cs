namespace Catel.Examples.WPF.Prism.ViewModels
{
    using Catel.Messaging;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class ShellViewModel : ViewModelBase
    {
        #region Fields
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel(IMessageMediator messageMediator)
            : base(messageMediator)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Catel Prism example"; }
        }
        #endregion

        #region Commands
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        #endregion

        #region Methods
        // TODO: Create your methods here
        #endregion
    }
}