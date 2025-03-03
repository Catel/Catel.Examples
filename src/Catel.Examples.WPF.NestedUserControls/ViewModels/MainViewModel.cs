namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System.Collections.ObjectModel;
    using Models;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        #region Constructors
        public MainViewModel()
        {
            Houses = new ObservableCollection<HouseModel>(ModelGenerator.GenerateHouses());

            Title = "Nested User Controls Example";
        }
        #endregion

        #region Properties
        public ObservableCollection<HouseModel> Houses { get; private set; }
        #endregion
    }
}