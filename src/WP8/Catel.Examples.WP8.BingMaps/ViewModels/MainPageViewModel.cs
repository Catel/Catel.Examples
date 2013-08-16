// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WP8.BingMaps.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Device.Location;
    using Catel.Data;
    using Data;
    using IoC;
    using MVVM;
    using MVVM.Services;
    using MVVM.Services.Test;

    /// <summary>
    /// MainPage view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ILocationService _locationService;

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel(ILocationService locationService)
        {
            _locationService = locationService;

            PreviousMap = new Command<object, object>(OnPreviousMapExecute, OnPreviousMapCanExecute);
            NextMap = new Command<object, object>(OnNextMapExecute, OnNextMapCanExecute);

            AvailableMapSources = new ObservableCollection<BaseTileSource>
                                      {
                                          new BingAerial {Name = "Bing Aerial"},
                                          new BingRoad {Name = "Bing Road"},
                                          new Mapnik {Name = "OSM Mapnik"},
                                          new OsmaRender {Name = "OsmaRender"},
                                          new Google {Name = "Google Hybrid", MapType = GoogleType.Hybrid},
                                          new Google {Name = "Google Street", MapType = GoogleType.Street},
                                      };

            if (AvailableMapSources.Count > 0)
            {
                CurrentMap = AvailableMapSources[0];
            }

            // Initialize demo route, uncomment if you want to use the real location service of WP7
            InitializeDemoRoute();

            // For test purposes, we want to zoom in as well
            ZoomLevel = 19;

            // This is the actual subscription to the location service which you would regularly do in a view-model
            _locationService.LocationChanged += OnCurrentLocationChanged;
            _locationService.Start();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "My location"; }
        }

        #region Models
        #endregion

        #region View model
        /// <summary>
        /// Gets or sets the available map sources.
        /// </summary>
        public ObservableCollection<BaseTileSource> AvailableMapSources
        {
            get { return GetValue<ObservableCollection<BaseTileSource>>(AvailableMapSourcesProperty); }
            set { SetValue(AvailableMapSourcesProperty, value); }
        }

        /// <summary>
        /// Register the AvailableMapSources property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AvailableMapSourcesProperty = RegisterProperty("AvailableMapSources", typeof (ObservableCollection<BaseTileSource>));

        /// <summary>
        /// Gets or sets the current map.
        /// </summary>
        public BaseTileSource CurrentMap
        {
            get { return GetValue<BaseTileSource>(CurrentMapProperty); }
            set { SetValue(CurrentMapProperty, value); }
        }

        /// <summary>
        /// Register the CurrentMap property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CurrentMapProperty = RegisterProperty("CurrentMap", typeof (BaseTileSource));

        /// <summary>
        /// Gets or sets the map center.
        /// </summary>
        public GeoCoordinate MapCenter
        {
            get { return GetValue<GeoCoordinate>(MapCenterProperty); }
            set { SetValue(MapCenterProperty, value); }
        }

        /// <summary>
        /// Register the MapCenter property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MapCenterProperty = RegisterProperty("MapCenter", typeof (GeoCoordinate));

        /// <summary>
        /// Gets or sets the zoom level.
        /// </summary>
        public double ZoomLevel
        {
            get { return GetValue<double>(ZoomLevelProperty); }
            set { SetValue(ZoomLevelProperty, value); }
        }

        /// <summary>
        /// Register the ZoomLevel property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ZoomLevelProperty = RegisterProperty("ZoomLevel", typeof (double));
        #endregion

        #endregion

        #region Commands
        /// <summary>
        /// Gets the PreviousMap command.
        /// </summary>
        public Command<object, object> PreviousMap { get; private set; }

        /// <summary>
        /// Method to check whether the PreviousMap command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnPreviousMapCanExecute(object parameter)
        {
            return AvailableMapSources.Count > 1;
        }

        /// <summary>
        /// Method to invoke when the PreviousMap command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnPreviousMapExecute(object parameter)
        {
            var newIdx = AvailableMapSources.IndexOf(CurrentMap) - 1;
            CurrentMap = AvailableMapSources[newIdx < 0 ? AvailableMapSources.Count - 1 : newIdx];
        }

        /// <summary>
        /// Gets the NextMap command.
        /// </summary>
        public Command<object, object> NextMap { get; private set; }

        /// <summary>
        /// Method to check whether the NextMap command can be executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private bool OnNextMapCanExecute(object parameter)
        {
            return AvailableMapSources.Count > 1;
        }

        /// <summary>
        /// Method to invoke when the NextMap command is executed.
        /// </summary>
        /// <param name="parameter">The parameter of the command.</param>
        private void OnNextMapExecute(object parameter)
        {
            var newIdx = AvailableMapSources.IndexOf(CurrentMap) + 1;
            CurrentMap = AvailableMapSources[newIdx > AvailableMapSources.Count - 1 ? 0 : newIdx];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Closes this instance. Always called after the <see cref="Cancel"/> of <see cref="Save"/> method.
        /// </summary>
        /// <remarks>
        /// When implementing this method in a base class, make sure to call the base, otherwise <see cref="IsClosed"/> will
        /// not be set to true.
        /// </remarks>
        protected override void Close()
        {
            _locationService.LocationChanged -= OnCurrentLocationChanged;
            _locationService.Stop();

            base.Close();
        }

        /// <summary>
        /// Called when the current location on the location service has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Catel.MVVM.Services.LocationChangedEventArgs"/> instance containing the event data.</param>
        private void OnCurrentLocationChanged(object sender, LocationChangedEventArgs e)
        {
            // Only update if there is a new location, otherwise assume that the user wants to see the last position
            if (e.Location != null)
            {
                MapCenter = new GeoCoordinate(e.Location.Latitude, e.Location.Longitude, e.Location.Altitude);
            }
        }

        /// <summary>
        /// Initializes the demo route for test purposes.
        /// <para />
        /// Calling this method will register the test version of the <see cref="ILocationService"/>.
        /// </summary>
        private void InitializeDemoRoute()
        {
            // This is a demo app, register test version of the service
            // In normal situations, you would not directly cast a service to a specific type in your view-model,
            // only in unit tests to set the expected locations. However, since we simply want to show the power
            // of IoC in combination with the location service, we register the service here and directly retrieve
            // it to simulate a user walking through a street
            IoC.ServiceLocator.Default.RegisterType<ILocationService, MVVM.Services.Test.LocationService>();
            var testLocationService = (MVVM.Services.Test.LocationService)_locationService;

            var timeSpan = new TimeSpan(0, 0, 0, 0, 500);

            // First one is longer because maps need to initialize
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38772d, 5.56484d), new TimeSpan(0, 0, 0, 5)));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38771d, 5.56484d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38770d, 5.56484d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38769d, 5.56483d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38768d, 5.56483d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38767d, 5.56483d), timeSpan));

            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38766d, 5.56482d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38765d, 5.56482d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38764d, 5.56482d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38763d, 5.56481d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38762d, 5.56481d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38761d, 5.56481d), timeSpan));

            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38760d, 5.56480d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38759d, 5.56480d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38758d, 5.56480d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38757d, 5.56479d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38756d, 5.56479d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38755d, 5.56479d), timeSpan));

            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38754d, 5.56478d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38753d, 5.56478d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38752d, 5.56478d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38751d, 5.56477d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38750d, 5.56477d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38749d, 5.56477d), timeSpan));

            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38748d, 5.56476d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38747d, 5.56476d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38746d, 5.56476d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38745d, 5.56475d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38744d, 5.56475d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38743d, 5.56475d), timeSpan));

            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38742d, 5.56474d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38741d, 5.56474d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38740d, 5.56474d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38739d, 5.56473d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38738d, 5.56473d), timeSpan));
            testLocationService.ExpectedLocations.Enqueue(new LocationTestData(new Location(51.38737d, 5.56473d), timeSpan));
        }
        #endregion
    }
}