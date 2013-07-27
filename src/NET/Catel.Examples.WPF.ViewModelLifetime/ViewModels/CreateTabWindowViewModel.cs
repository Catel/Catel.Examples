namespace Catel.Examples.WPF.ViewModelLifetime.ViewModels
{
    using Catel.MVVM;
    using Data;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class CreateTabWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTabWindowViewModel"/> class.
        /// </summary>
        public CreateTabWindowViewModel()
        {
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Create new tab"; } }

        /// <summary>
        /// Gets or sets whether the new tab should close the view model when unloaded.
        /// </summary>
        public bool CloseWhenUnloaded
        {
            get { return GetValue<bool>(CloseWhenUnloadedProperty); }
            set { SetValue(CloseWhenUnloadedProperty, value); }
        }

        /// <summary>
        /// Register the CloseWhenUnloaded property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CloseWhenUnloadedProperty = RegisterProperty("CloseWhenUnloaded", typeof(bool), true);
    }
}
