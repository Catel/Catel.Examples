namespace Catel.Examples.Commanding.ViewModels
{
    using System;
    using Catel.Data;
    using Catel.MVVM;

    public class DocumentViewModel : ViewModelBase
    {
        public DocumentViewModel(ICommandManager commandManager)
        {
            ArgumentNullException.ThrowIfNull(commandManager);

            ExampleCommand = new Command(OnExampleCommandExecute);

            // This will register the VM command with the global command. As soon as the view model gets unloaded,
            // it will also unsubscribe itself from the global command
            commandManager.RegisterCommand(Commands.Refresh, ExampleCommand, this);
        }

        public DateTime LastCommandExecutionDateTime { get; set; }

        public Command ExampleCommand { get; private set; }

        private void OnExampleCommandExecute()
        {
            LastCommandExecutionDateTime = DateTime.Now;
        }
    }
}