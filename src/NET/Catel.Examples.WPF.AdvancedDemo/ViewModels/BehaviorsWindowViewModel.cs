namespace Catel.Examples.AdvancedDemo.ViewModels
{
    using System.Threading.Tasks;
    using Catel.MVVM;
    using Catel.Services;
    using Data;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class BehaviorsWindowViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorsWindowViewModel"/> class.
        /// </summary>
        public BehaviorsWindowViewModel(IMessageService messageService)
        {
            _messageService = messageService;

            DoubleClickToCommandExample = new TaskCommand(OnDoubleClickToCommandExampleExecuteAsync);
            EventToCommandForLostFocus = new TaskCommand(OnEventToCommandForLostFocusExecuteAsync);
            KeyPressToCommandExample = new TaskCommand(OnKeyPressToCommandExampleExecuteAsync);
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Behaviors"; } }

        #region Properties
        /// <summary>
        /// Gets or sets the DelayBindingUpdateValue.
        /// </summary>
        public string DelayBindingUpdateValue
        {
            get { return GetValue<string>(DelayBindingUpdateValueProperty); }
            set { SetValue(DelayBindingUpdateValueProperty, value); }
        }

        /// <summary>
        /// Register the DelayBindingUpdateValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DelayBindingUpdateValueProperty = RegisterProperty("DelayBindingUpdateValue", typeof(string),
            null, (sender, e) => ((BehaviorsWindowViewModel)sender).OnDelayBindingUpdateValueChanged());

        /// <summary>
        /// Gets or sets the UpdateBindingOnTextChangedValue.
        /// </summary>
        public string UpdateBindingOnTextChangedValue
        {
            get { return GetValue<string>(UpdateBindingOnTextChangedValueProperty); }
            set { SetValue(UpdateBindingOnTextChangedValueProperty, value); }
        }

        /// <summary>
        /// Register the UpdateBindingOnTextChangedValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData UpdateBindingOnTextChangedValueProperty = RegisterProperty("UpdateBindingOnTextChangedValue", typeof(string));

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public double NumericValue
        {
            get { return GetValue<double>(NumericValueProperty); }
            set { SetValue(NumericValueProperty, value); }
        }

        /// <summary>
        /// Register the NumericValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NumericValueProperty = RegisterProperty("NumericValue", typeof(double), 0d);
        #endregion

        #region Commands
        /// <summary>
        /// Gets the DoubleClickToCommandExample command.
        /// </summary>
        public TaskCommand DoubleClickToCommandExample { get; private set; }

        /// <summary>
        /// Method to invoke when the DoubleClickToCommandExample command is executed.
        /// </summary>
        private async Task OnDoubleClickToCommandExampleExecuteAsync()
        {
            await _messageService.ShowAsync("Received double click");
        }

        /// <summary>
        /// Gets the EventToCommandForLostFocus command.
        /// </summary>
        public TaskCommand EventToCommandForLostFocus { get; private set; }

        /// <summary>
        /// Method to invoke when the EventToCommandForLostFocus command is executed.
        /// </summary>
        private async Task OnEventToCommandForLostFocusExecuteAsync()
        {
            await _messageService.ShowAsync("LostFocus event occurred");
        }

        /// <summary>
        /// Gets the KeyPressToCommandExample command.
        /// </summary>
        public TaskCommand KeyPressToCommandExample { get; private set; }

        /// <summary>
        /// Method to invoke when the KeyPressToCommandExample command is executed.
        /// </summary>
        private async Task OnKeyPressToCommandExampleExecuteAsync()
        {
            await _messageService.ShowAsync("You just pressed the [Ctrl] + [Backspace] keys");
        }
        #endregion

        #region Methods
        private async void OnDelayBindingUpdateValueChanged()
        {
            await _messageService.ShowAsync(string.Format("New value is {0}", DelayBindingUpdateValue));
        }
        #endregion
    }
}
