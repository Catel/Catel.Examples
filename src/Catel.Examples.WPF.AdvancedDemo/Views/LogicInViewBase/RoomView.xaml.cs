namespace Catel.Examples.AdvancedDemo.Views.LogicInViewBase
{
    using Windows.Controls;

    /// <summary>
    /// Interaction logic for RoomView.xaml.
    /// </summary>
    public partial class RoomView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomView"/> class.
        /// </summary>
        public RoomView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the type of the view model. If this method returns <c>null</c>, the view model type will be retrieved by naming
        /// convention using the <see cref="T:Catel.MVVM.IViewModelLocator"/> registered in the <see cref="T:Catel.IoC.IServiceLocator"/>.
        /// </summary>
        /// <returns>The type of the view model or <c>null</c> in case it should be auto determined.</returns>
        /// <remarks></remarks>
        protected override System.Type GetViewModelType()
        {
            return typeof(ViewModels.RoomViewModel);
        }
    }
}
