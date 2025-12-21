namespace Catel.Examples.MasterDetail.Views
{
    using System;
    using Catel.MVVM;
    using Catel.Services;

    public partial class PersonMasterView
    {
        public PersonMasterView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService,
            IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}
