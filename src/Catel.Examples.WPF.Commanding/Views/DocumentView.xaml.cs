namespace Catel.Examples.Commanding.Views
{
    using System;
    using Catel.MVVM;
    using Catel.Services;

    public partial class DocumentView
    {
        //public DocumentView(IServiceProvider serviceProvider, IViewModelWrapperService viewModelWrapperService,
        //    IDataContextSubscriptionService dataContextSubscriptionService)
        //    : base(serviceProvider, viewModelWrapperService, dataContextSubscriptionService)
        public DocumentView(IServiceProvider serviceProvider)
            : base(serviceProvider, null!, null!)
        {
            InitializeComponent();
        }
    }
}
