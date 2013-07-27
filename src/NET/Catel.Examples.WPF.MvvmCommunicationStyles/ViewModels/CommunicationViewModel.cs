// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Data;
    using MVVM;

    public abstract class CommunicationViewModel : ViewModelBase
    {
        private int _counterA;
        private int _counterB;

        public CommunicationViewModel()
        {
            ReceivedPropertyChanges = new ObservableCollection<string>();
            ReceivedCommands = new ObservableCollection<string>();

            ExampleCommand = new Command(OnExampleCommandExecute);
        }

        /// <summary>
        /// Gets or sets the first property.
        /// </summary>
        public string PropA
        {
            get { return GetValue<string>(PropAProperty); }
            set { SetValue(PropAProperty, value); }
        }

        /// <summary>
        /// Register the PropA property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PropAProperty = RegisterProperty("PropA", typeof(string), null);

        /// <summary>
        /// Gets or sets the second property.
        /// </summary>
        public string PropB
        {
            get { return GetValue<string>(PropBProperty); }
            set { SetValue(PropBProperty, value); }
        }

        /// <summary>
        /// Register the PropB property so it is known in the class.
        /// </summary>
        public static readonly PropertyData PropBProperty = RegisterProperty("PropB", typeof(string), null);

        /// <summary>
        /// Gets the received property changes.
        /// </summary>
        public ObservableCollection<string> ReceivedPropertyChanges
        {
            get { return GetValue<ObservableCollection<string>>(ReceivedPropertyChangesProperty); }
            private set { SetValue(ReceivedPropertyChangesProperty, value); }
        }

        /// <summary>
        /// Register the ReceivedPropertyChanges property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ReceivedPropertyChangesProperty = RegisterProperty("ReceivedPropertyChanges", typeof(ObservableCollection<string>), null);

        /// <summary>
        /// Gets the received commands.
        /// </summary>
        public ObservableCollection<string> ReceivedCommands
        {
            get { return GetValue<ObservableCollection<string>>(ReceivedCommandsProperty); }
            private set { SetValue(ReceivedCommandsProperty, value); }
        }

        /// <summary>
        /// Register the ReceivedCommands property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ReceivedCommandsProperty = RegisterProperty("ReceivedCommands", typeof(ObservableCollection<string>), null);

        public void UpdatePropA()
        {
            PropA = _counterA++.ToString();
        }

        public void UpdatePropB()
        {
            PropB = _counterB++.ToString();
        }

        public Command ExampleCommand { get; private set; }

        private void OnExampleCommandExecute()
        {
            ExecuteCommand();
        }

        protected abstract void ExecuteCommand();

        protected void AddPropertyChange(string propertyName, Type senderType)
        {
            Argument.IsNotNull(() => propertyName);
            Argument.IsNotNull(() => senderType);

            ReceivedPropertyChanges.Add(string.Format("Property '{0}' on type '{1}' has changed", propertyName, senderType.Name));
        }

        protected void AddCommand(Type senderType)
        {
            Argument.IsNotNull(() => senderType);

            ReceivedCommands.Add(string.Format("Type '{0}' has executed a command", senderType.Name));
        }
    }
}