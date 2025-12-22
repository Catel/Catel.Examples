namespace Catel.Examples.Commanding.ViewModels
{
    using System;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IServiceProvider serviceProvider)
        {
            Title = "Commanding example";
        }
    }
}
