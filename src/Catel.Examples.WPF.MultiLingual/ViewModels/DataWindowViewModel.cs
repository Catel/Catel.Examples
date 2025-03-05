namespace Catel.Examples.MultiLingual.ViewModels
{
    using System;
    using Models;
    using MVVM;

    public class DataWindowViewModel : ViewModelBase
    {
        public DataWindowViewModel(Language language)
        {
            ArgumentNullException.ThrowIfNull(language);

            Language = language;

            Title = "MultiLingual example";
        }

        [Model]
        [Fody.Expose("Name")]
        [Fody.Expose("Code")]
        private Language Language { get; set; }
    }
}
