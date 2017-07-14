// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandExecutedMessage.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.ViewModels
{
    using MVVM;

    public class CommandExecutedMessage
    {
        public CommandExecutedMessage(IViewModel sender)
        {
            Argument.IsNotNull(() => sender);

            Sender = sender;
        }

        public IViewModel Sender { get; private set; }
    }
}