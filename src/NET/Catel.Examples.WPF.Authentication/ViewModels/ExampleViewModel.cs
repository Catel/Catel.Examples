namespace Catel.Examples.WPF.Authentication.ViewModels
{
    using MVVM;

    /// <summary>
    /// Example view model.
    /// </summary>
    public class ExampleViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleViewModel"/> class.
        /// </summary>
        public ExampleViewModel()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Authentication example"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        #endregion

        #region Commands
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        #endregion

        #region Methods
        #endregion
    }
}
