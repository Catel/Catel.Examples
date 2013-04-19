// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterestedInAViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Examples.MvvmCommunicationStyles.ViewModels
{
    using Catel.MVVM;

    [InterestedIn(typeof(InterestedInBViewModel))]
    public class InterestedInAViewModel : CommunicationViewModel
    {
        protected override void OnViewModelPropertyChanged(IViewModel viewModel, string propertyName)
        {
            AddPropertyChange(propertyName, viewModel.GetType());
        }

        protected override void OnViewModelCommandExecuted(IViewModel viewModel, ICatelCommand command, object commandParameter)
        {
            AddCommand(viewModel.GetType());
        }

        protected override void ExecuteCommand()
        {
            // InterestedIn does not required any custom logic
        }
    }
}