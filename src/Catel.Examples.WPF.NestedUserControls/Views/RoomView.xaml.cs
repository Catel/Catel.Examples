namespace Catel.Examples.NestedUserControls.Views
{
    using System;
    using Catel.MVVM;
    using Catel.Services;

    public partial class RoomView 
    {
        public RoomView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService,
            IDataContextSubscriptionService dataContextSubscriptionService)
            : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        {
            InitializeComponent();
        }
    }
}
