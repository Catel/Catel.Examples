// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyChangedMessage.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.ViewModels
{
    using MVVM;

    public class PropertyChangedMessage
    {
        public PropertyChangedMessage(IViewModel sender, string propertyName)
        {
            Argument.IsNotNull(() => sender);
            Argument.IsNotNull(() => propertyName);

            Sender = sender;
            PropertyName = propertyName;
        }

        public IViewModel Sender { get; private set; }

        public string PropertyName { get; private set; }
    }
}