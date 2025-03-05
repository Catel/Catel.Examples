namespace Catel.Examples.Behaviors.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    public class MainViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;

        public MainViewModel(IMessageService messageService)
        {
            ArgumentNullException.ThrowIfNull(messageService);

            _messageService = messageService;

            DoubleClickToCommandExample = new TaskCommand(OnDoubleClickToCommandExampleExecuteAsync);
            EventToCommandForLostFocus = new TaskCommand(OnEventToCommandForLostFocusExecuteAsync);
            KeyPressToCommandExample = new TaskCommand(OnKeyPressToCommandExampleExecuteAsync);

            Title = "Behaviors";

            ListItems = new[]
            {
                "1",
                "2",
                "3",
                "4"
            };
        }

        public string DelayBindingUpdateValue { get; set; }

        public string UpdateBindingOnTextChangedValue { get; set; }

        public IReadOnlyList<string> ListItems { get; private set; }

        public double NumericValue { get; set; }

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

        private async void OnDelayBindingUpdateValueChanged()
        {
            await _messageService.ShowAsync($"New value is {DelayBindingUpdateValue}");
        }
    }
}
