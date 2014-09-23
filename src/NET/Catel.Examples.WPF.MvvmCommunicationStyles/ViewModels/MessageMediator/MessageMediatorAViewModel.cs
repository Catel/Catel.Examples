// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMediatorAViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.ViewModels
{
    using System.Threading.Tasks;
    using Messaging;

    public class MessageMediatorAViewModel : CommunicationViewModel
    {
        private readonly IMessageMediator _messageMediator;

        public MessageMediatorAViewModel(IMessageMediator messageMediator)
        {
            _messageMediator = messageMediator;
        }

        protected override async Task Initialize()
        {
            _messageMediator.Register<PropertyChangedMessage>(this, OnPropertyChangedMessageReceived);
            _messageMediator.Register<CommandExecutedMessage>(this, OnCommandExecutedMessageReceived);
        }

        protected override async Task Close()
        {
            _messageMediator.UnregisterRecipientAndIgnoreTags(this);
        }

        public void OnPropertyChangedMessageReceived(PropertyChangedMessage message)
        {
            if (ReferenceEquals(this, message.Sender))
            {
                return;
            }

            AddPropertyChange(message.PropertyName, message.Sender.GetType());
        }

        public void OnCommandExecutedMessageReceived(CommandExecutedMessage message)
        {
            if (ReferenceEquals(this, message.Sender))
            {
                return;
            }

            AddCommand(message.Sender.GetType());
        }

        protected override void OnPropertyChanged(Data.AdvancedPropertyChangedEventArgs e)
        {
            if (_messageMediator == null)
            {
                return;
            }

            _messageMediator.SendMessage(new PropertyChangedMessage(this, e.PropertyName));
        }

        protected override void ExecuteCommand()
        {
            if (_messageMediator == null)
            {
                return;
            }

            _messageMediator.SendMessage(new CommandExecutedMessage(this));
        }
    }
}