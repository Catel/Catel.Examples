// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Behaviors.ViewModels
{
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        #endregion

        #region Constructors
        public MainViewModel(IMessageService messageService)
        {
            Argument.IsNotNull(() => messageService);

            _messageService = messageService;

            DoubleClickToCommandExample = new TaskCommand(OnDoubleClickToCommandExampleExecuteAsync);
            EventToCommandForLostFocus = new TaskCommand(OnEventToCommandForLostFocusExecuteAsync);
            KeyPressToCommandExample = new TaskCommand(OnKeyPressToCommandExampleExecuteAsync);

            Title = "Behaviors";
        }
        #endregion

        #region Properties
        public string DelayBindingUpdateValue { get; set; }

        public string UpdateBindingOnTextChangedValue { get; set; }

        public double NumericValue { get; set; }
        #endregion

        #region Commands
        public TaskCommand DoubleClickToCommandExample { get; private set; }

        private async Task OnDoubleClickToCommandExampleExecuteAsync()
        {
            await _messageService.ShowAsync("Received double click");
        }

        public TaskCommand EventToCommandForLostFocus { get; private set; }

        private async Task OnEventToCommandForLostFocusExecuteAsync()
        {
            await _messageService.ShowAsync("LostFocus event occurred");
        }

        public TaskCommand KeyPressToCommandExample { get; private set; }

        private async Task OnKeyPressToCommandExampleExecuteAsync()
        {
            await _messageService.ShowAsync("You just pressed the [Ctrl] + [Backspace] keys");
        }
        #endregion

        #region Methods
        private async void OnDelayBindingUpdateValueChanged()
        {
            await _messageService.ShowAsync($"New value is {DelayBindingUpdateValue}");
        }
        #endregion
    }
}