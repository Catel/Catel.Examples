namespace Catel.Examples.WinRT.Advanced.ViewModels
{
    using System.Collections.ObjectModel;
    using Data;
    using MVVM;
    using Models;

    /// <summary>
    /// NestedUserControlsWindow view model.
    /// </summary>
    public class NestedUserControlsViewModel : NavigationViewModelBase
    {
        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedUserControlsViewModel"/> class.
        /// </summary>
        public NestedUserControlsViewModel()
        {
            Houses = new ObservableCollection<HouseModel>(ModelGenerator.GenerateHouses());
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Nested User Controls Example"; } }

        /// <summary>
        /// Gets or sets the houses.
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
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        #endregion

        #region Methods
        #endregion
    }
}
