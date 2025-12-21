namespace Catel.Examples.NestedUserControls.Views
{
    using System;
    using Catel.MVVM;
    using Catel.Services;

    public partial class HouseView
    {
        public HouseView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService,
            IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}
