namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using MVVM;
    using Services;

    public class DemoWindowViewModel : FeaturedViewModelBase
    {
        private readonly IMessageService _messageService;

        public DemoWindowViewModel(IServiceProvider serviceProvider, IMessageService messageService)
            : base(serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(messageService);

            _messageService = messageService;

            Person = new PersonModel();

            Title = "Person demo";
        }

        [Model]
        public PersonModel Person { get; private set; }

        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }

        [ViewModelToModel("Person")]
        public string LastName { get; set; }

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
    }
}
