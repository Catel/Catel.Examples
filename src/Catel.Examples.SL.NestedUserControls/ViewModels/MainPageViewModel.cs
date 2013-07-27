namespace Catel.Examples.SL4.NestedUserControls.ViewModels
{
    using System.Collections.ObjectModel;
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// MainPage view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            Houses = new ObservableCollection<HouseModel>(ModelGenerator.GenerateHouses());
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Nested user controls in Silverlight"; }
        }

        /// <summary>
        /// Gets the collection of houses.
        /// </summary>
        public ObservableCollection<HouseModel> Houses
        {
            get { return GetValue<ObservableCollection<HouseModel>>(HousesProperty); }
            set { SetValue(HousesProperty, value); }
        }

        /// <summary>
        /// Register the Houses property so it is known in the class.
        /// </summary>
        public static readonly PropertyData HousesProperty = RegisterProperty("Houses", typeof(ObservableCollection<HouseModel>));
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}
