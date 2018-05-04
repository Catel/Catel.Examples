// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DemoWindowViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System.Threading.Tasks;
    using Data;
    using Models;
    using MVVM;
    using Services;

    public class DemoWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IMessageService _messageService;
        #endregion

        #region Constructors
        public DemoWindowViewModel(IMessageService messageService)
        {
            Argument.IsNotNull(() => messageService);

            _messageService = messageService;

            Person = new PersonModel();

            Title = "Person demo";
        }
        #endregion

        #region Properties
        [Model]
        public PersonModel Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }
        #endregion

        #region Methods
        protected override async Task<bool> CancelAsync()
        {
            await _messageService.ShowInformationAsync("View model canceled");

            return await base.CancelAsync();
        }

        protected override async Task<bool> SaveAsync()
        {
            await _messageService.ShowInformationAsync("View model saved");

            return await base.SaveAsync();
        }

        protected override async Task CloseAsync()
        {
            await _messageService.ShowInformationAsync("View model closed");

            await base.CloseAsync();
        }
        #endregion
    }
}