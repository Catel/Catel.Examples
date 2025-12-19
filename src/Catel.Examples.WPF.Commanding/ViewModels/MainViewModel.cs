namespace Catel.Examples.Commanding.ViewModels
{
    using System;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Title = "Commanding example";
        }
    }
}
