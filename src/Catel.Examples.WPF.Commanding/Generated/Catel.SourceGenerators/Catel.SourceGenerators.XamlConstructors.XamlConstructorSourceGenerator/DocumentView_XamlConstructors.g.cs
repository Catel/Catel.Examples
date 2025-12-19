using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Catel.IoC;

namespace Catel.Examples.Commanding.Views
{
    partial class DocumentView
    {
        [CompilerGenerated]
        public DocumentView()
            : this(IoCContainer.ServiceProvider.GetRequiredService<System.IServiceProvider>(), IoCContainer.ServiceProvider.GetRequiredService<Catel.Services.IViewModelWrapperService>(), IoCContainer.ServiceProvider.GetRequiredService<Catel.MVVM.IDataContextSubscriptionService>())
        {
        }
    }
}
