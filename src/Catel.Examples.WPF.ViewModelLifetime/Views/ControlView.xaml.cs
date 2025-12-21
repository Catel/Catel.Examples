namespace Catel.Examples.ViewModelLifetime.Views
{
    using System;
    using Catel.MVVM;
    using Catel.Services;

    public partial class ControlView
    {
        public ControlView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService,
            IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}
