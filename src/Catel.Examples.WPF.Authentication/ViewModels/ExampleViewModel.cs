namespace Catel.Examples.Authentication.ViewModels
{
    using System;
    using MVVM;

    public class ExampleViewModel : ViewModelBase
    {
        public ExampleViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Title = "Authentication example";
        }
    }
}
