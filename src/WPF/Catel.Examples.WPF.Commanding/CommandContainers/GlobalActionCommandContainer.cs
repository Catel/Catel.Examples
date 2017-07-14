// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsGlobalActionCommandContainer.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Commanding.CommandContainers
{
    using System.Threading.Tasks;
    using MVVM;
    using Services;

    internal class GlobalActionCommandContainer : CommandContainerBase
    {
        private readonly IMessageService _messageService;

        public GlobalActionCommandContainer(ICommandManager commandManager, IMessageService messageService) 
            : base(Commands.GlobalAction, commandManager)
        {
            Argument.IsNotNull(() => messageService);

            _messageService = messageService;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            await _messageService.ShowAsync("Global action from command in command container");
        }
    }
}