namespace Catel.Examples.ViewModelLifetime.Services
{
    public interface ITabService
    {
        #region Methods
        void AddTab(bool closeViewModelOnUnload);
        #endregion
    }
}