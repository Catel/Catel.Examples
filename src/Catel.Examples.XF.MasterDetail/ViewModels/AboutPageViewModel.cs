namespace Catel.Examples.Xamarin.Forms.MasterDetail.ViewModels
{
    using System;
    using System.Windows.Input;
    using Catel.MVVM;

    using global::Xamarin.Essentials;
    using global::Xamarin.Forms;

    public class AboutPageViewModel : ViewModelBase
    {
        public AboutPageViewModel()
        {
            OpenWebCommand = new MVVM.Command(async () => await Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));
            OpenCatelWebCommand = new MVVM.Command(async () => await Launcher.OpenAsync(new Uri("http://www.catelproject.com")));
        }

        public ICommand OpenCatelWebCommand { get; }

        public override string Title => "About";

        /// <summary>
        ///     Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
