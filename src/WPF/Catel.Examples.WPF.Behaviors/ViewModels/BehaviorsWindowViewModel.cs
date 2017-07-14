// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehaviorsWindowViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Behaviors.ViewModels
{
    using System.Threading.Tasks;
    using Data;
    using MVVM;
    using Services;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class BehaviorsWindowViewModel : ViewModelBase
    {
        #region Constants
        /// <summary>
        /// Register the DelayBindingUpdateValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData DelayBindingUpdateValueProperty = RegisterProperty("DelayBindingUpdateValue", typeof(string),
            null, (sender, e) => ((BehaviorsWindowViewModel) sender).OnDelayBindingUpdateValueChanged());

        /// <summary>
        /// Register the UpdateBindingOnTextChangedValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData UpdateBindingOnTextChangedValueProperty = RegisterProperty("UpdateBindingOnTextChangedValue", typeof(string));

        /// <summary>
        /// Register the NumericValue property so it is known in the class.
        /// </summary>
        public static readonly PropertyData NumericValueProperty = RegisterProperty("NumericValue", typeof(double), 0d);
        #endregion

        #region Fields
        private readonly IMessageService _messageService;
        #endregion

        #region Constructors
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
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Behaviors"; }
        }

        /// <summary>
        /// Gets or sets the DelayBindingUpdateValue.
        /// </summary>
        public string DelayBindingUpdateValue
        {
            get { return GetValue<string>(DelayBindingUpdateValueProperty); }
            set { SetValue(DelayBindingUpdateValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the UpdateBindingOnTextChangedValue.
        /// </summary>
        public string UpdateBindingOnTextChangedValue
        {
            get { return GetValue<string>(UpdateBindingOnTextChangedValueProperty); }
            set { SetValue(UpdateBindingOnTextChangedValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public double NumericValue
        {
            get { return GetValue<double>(NumericValueProperty); }
            set { SetValue(NumericValueProperty, value); }
        }
        #endregion

        #region Methods
        private async void OnDelayBindingUpdateValueChanged()
        {
            await _messageService.ShowAsync(string.Format("New value is {0}", DelayBindingUpdateValue));
        }
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
    }
}