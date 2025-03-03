namespace Catel.Examples.Commanding.CommandContainers
{
    using System;
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    internal class GlobalActionCommandContainer : CommandContainerBase
    {
        private readonly IMessageService _messageService;

        public GlobalActionCommandContainer(ICommandManager commandManager, IMessageService messageService) 
            : base(Commands.GlobalAction, commandManager)
        {
            ArgumentNullException.ThrowIfNull(messageService);

            _messageService = messageService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _messageService.ShowAsync("Global action from command in command container");
        }
    }
    
    internal class Test1CommandContainer : CommandContainerBase
    {
        private readonly IMessageService _messageService;

        public Test1CommandContainer(ICommandManager commandManager, IMessageService messageService) 
            : base(Commands.Test1, commandManager)
        {
            ArgumentNullException.ThrowIfNull(messageService);

            _messageService = messageService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _messageService.ShowAsync("Test1 from command in command container");
        }
    }
    
    internal class Test2CommandContainer : CommandContainerBase
    {
        private readonly IMessageService _messageService;

        public Test2CommandContainer(ICommandManager commandManager, IMessageService messageService) 
            : base(Commands.Test2, commandManager)
        {
            ArgumentNullException.ThrowIfNull(messageService);

            _messageService = messageService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _messageService.ShowAsync("Test2 from command in command container");
        }
    }
}
