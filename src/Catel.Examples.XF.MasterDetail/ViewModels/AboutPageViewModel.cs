namespace Catel.Examples.Xamarin.Forms.MasterDetail.ViewModels
{
    using System;
    using System.Windows.Input;

    using Catel.MVVM;

    using global::Xamarin.Essentials;

    public class AboutPageViewModel : ViewModelBase
    {
        #region Constructors
        public AboutPageViewModel()
        {
            OpenWebCommand = new TaskCommand(() => Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));
            OpenCatelWebCommand = new TaskCommand(() => Launcher.OpenAsync(new Uri("http://www.catelproject.com")));
        }
        #endregion

        #region Properties
        public ICommand OpenCatelWebCommand { get; }

        public override string Title => "About";

        /// <summary>
        ///     Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
        #endregion
    }
}
