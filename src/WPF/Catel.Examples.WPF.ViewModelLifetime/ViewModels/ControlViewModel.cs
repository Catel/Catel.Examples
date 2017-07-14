namespace Catel.Examples.WPF.ViewModelLifetime.ViewModels
{
    using Catel.MVVM;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class ControlViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlViewModel"/> class.
        /// </summary>
        public ControlViewModel()
        {
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Tab control"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
    }
}
