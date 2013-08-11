// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SplashScreenView.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for SplashScreenWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.DisplayProgress.Views
{
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreenWindow"/> class.
        /// </summary>
        public SplashScreenWindow()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();
        }

        #endregion
    }
}