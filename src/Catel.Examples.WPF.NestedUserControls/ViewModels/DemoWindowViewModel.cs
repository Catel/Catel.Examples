namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using System.Threading.Tasks;
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
            ArgumentNullException.ThrowIfNull(messageService);

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
