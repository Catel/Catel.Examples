namespace Catel.Examples.ViewModelLifetime.ViewModels
{
    using MVVM;

    public class CreateTabWindowViewModel : ViewModelBase
    {
        #region Constructors
        public CreateTabWindowViewModel()
        {
            Title = "Create new tab";
        }
        #endregion

        #region Properties
        public bool CloseWhenUnloaded { get; set; }
        #endregion
    }
}