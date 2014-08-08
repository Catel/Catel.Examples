namespace Catel.Examples.AdvancedDemo.ViewModels
{
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

            DoubleClickToCommandExample = new Command(OnDoubleClickToCommandExampleExecute);
            EventToCommandForLostFocus = new Command(OnEventToCommandForLostFocusExecute);
            KeyPressToCommandExample = new Command(OnKeyPressToCommandExampleExecute);
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
        #endregion

        #region Commands
        /// <summary>
        /// Gets the DoubleClickToCommandExample command.
        /// </summary>
        public Command DoubleClickToCommandExample { get; private set; }

        /// <summary>
        /// Method to invoke when the DoubleClickToCommandExample command is executed.
        /// </summary>
        private void OnDoubleClickToCommandExampleExecute()
        {
            _messageService.Show("Received double click");
        }

        /// <summary>
        /// Gets the EventToCommandForLostFocus command.
        /// </summary>
        public Command EventToCommandForLostFocus { get; private set; }

        /// <summary>
        /// Method to invoke when the EventToCommandForLostFocus command is executed.
        /// </summary>
        private void OnEventToCommandForLostFocusExecute()
        {
            _messageService.Show("LostFocus event occurred");
        }

        /// <summary>
        /// Gets the KeyPressToCommandExample command.
        /// </summary>
        public Command KeyPressToCommandExample { get; private set; }

        /// <summary>
        /// Method to invoke when the KeyPressToCommandExample command is executed.
        /// </summary>
        private void OnKeyPressToCommandExampleExecute()
        {
            _messageService.Show("You just pressed the [Ctrl] + [Backspace] keys");
        }
        #endregion

        #region Methods
        private void OnDelayBindingUpdateValueChanged()
        {
            _messageService.Show(string.Format("New value is {0}", DelayBindingUpdateValue));
        }
        #endregion
    }
}
