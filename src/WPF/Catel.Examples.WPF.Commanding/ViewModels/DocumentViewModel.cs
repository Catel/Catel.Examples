// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WPF.Commanding.ViewModels
{
    using System;
    using Catel.Data;
    using Catel.MVVM;

    public class DocumentViewModel : ViewModelBase
    {
        public DocumentViewModel(ICommandManager commandManager)
        {
            ExampleCommand = new Command(OnExampleCommandExecute);

            commandManager.RegisterCommand(Commands.Refresh, ExampleCommand, this);
        }

        /// <summary>
        /// Gets the ExampleCommand command.
        /// </summary>
        public Command ExampleCommand { get; private set; }

        /// <summary>
        /// Method to invoke when the ExampleCommand command is executed.
        /// </summary>
        private void OnExampleCommandExecute()
        {
            LastCommandExecutionDateTime = DateTime.Now;
        }

        /// <summary>
        /// Gets the last command execution date time.
        /// </summary>
        public DateTime LastCommandExecutionDateTime
        {
            get { return GetValue<DateTime>(LastCommandExecutionDateTimeProperty); }
            set { SetValue(LastCommandExecutionDateTimeProperty, value); }
        }

        /// <summary>
        /// Register the name property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LastCommandExecutionDateTimeProperty = RegisterProperty("LastCommandExecutionDateTime", typeof(DateTime), null);
    }
}