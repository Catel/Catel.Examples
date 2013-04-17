namespace Catel.Examples.WPF.Prism.ViewModels
{
    using Messaging;

    /// <summary>
    /// View model base class specially made for the prism example with additional default properties.
    /// </summary>
    public abstract class ViewModelBase : MVVM.ViewModelBase
    {
        /// <summary>
        /// Gets the message mediator.
        /// </summary>
        public IMessageMediator MessageMediator { get { return GetService<IMessageMediator>(); } }
    }
}