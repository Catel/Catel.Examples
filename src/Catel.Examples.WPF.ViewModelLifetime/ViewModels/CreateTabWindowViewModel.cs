﻿namespace Catel.Examples.ViewModelLifetime.ViewModels
{
    using MVVM;

    public class CreateTabWindowViewModel : ViewModelBase
    {
        public CreateTabWindowViewModel()
        {
            Title = "Create new tab";
        }

        public bool CloseWhenUnloaded { get; set; }
    }
}
