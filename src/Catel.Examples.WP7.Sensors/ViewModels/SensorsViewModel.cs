namespace Catel.Examples.WP7.Sensors.ViewModels
{
    using System;
    using Data;
    using MVVM;
    using MVVM.Services;
    using MVVM.Services.Test;
    using AccelerometerService = MVVM.Services.AccelerometerService;
    using CompassService = MVVM.Services.CompassService;
    using GyroscopeService = MVVM.Services.GyroscopeService;
    using LocationService = MVVM.Services.LocationService;

    /// <summary>
    /// RealSensors view model.
    /// </summary>
    public class SensorsViewModel : ViewModelBase
    {
        #region Constants
        /// <summary>
        /// Minimum number of items in the test data set for test services.
        /// </summary>
        private const int MinimumTestDataSetCount = 3;
        #endregion

        #region Variables
        private IAccelerometerService _accelerometerService;
        private ICompassService _compassService;
        private IGyroscopeService _gyroscopeService;
        private ILocationService _locationService;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SensorsViewModel"/> class.
        /// </summary>
        public SensorsViewModel()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Sensors"; }
        }

        #region View model
        /// <summary>
        /// Gets a string representing the current mode.
        /// </summary>
        public string ServicesMode
        {
            get { return GetValue<string>(ServicesModeProperty); }
            set { SetValue(ServicesModeProperty, value); }
        }

        /// <summary>
        /// Register the ServicesMode property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ServicesModeProperty = RegisterProperty("ServicesMode", typeof (string));

        #region Accelerometer
        /// <summary>
        /// Gets the acceleratometer X.
        /// </summary>
        public double AccelerometerX
        {
            get { return GetValue<double>(AccelerometerXProperty); }
            private set { SetValue(AccelerometerXProperty, value); }
        }

        /// <summary>
        /// Register the AccelerometerX property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AccelerometerXProperty = RegisterProperty("AccelerometerX", typeof (double));

        /// <summary>
        /// Gets the accelerometer Y.
        /// </summary>
        public double AccelerometerY
        {
            get { return GetValue<double>(AccelerometerYProperty); }
            private set { SetValue(AccelerometerYProperty, value); }
        }

        /// <summary>
        /// Register the AccelerometerY property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AccelerometerYProperty = RegisterProperty("AccelerometerY", typeof (double));

        /// <summary>
        /// Gets the accelerometer Z.
        /// </summary>
        public double AccelerometerZ
        {
            get { return GetValue<double>(AccelerometerZProperty); }
            private set { SetValue(AccelerometerZProperty, value); }
        }

        /// <summary>
        /// Register the AccelerometerZ property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AccelerometerZProperty = RegisterProperty("AccelerometerZ", typeof (double));
        #endregion

        #region Compass
        /// <summary>
        /// Gets or sets the compass magnetic heading.
        /// </summary>
        public double CompassMagneticHeading
        {
            get { return GetValue<double>(CompassMagneticHeadingProperty); }
            set { SetValue(CompassMagneticHeadingProperty, value); }
        }

        /// <summary>
        /// Register the CompassMagneticHeading property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CompassMagneticHeadingProperty = RegisterProperty("CompassMagneticHeading", typeof (double));

        /// <summary>
        /// Gets or sets the compass true heading.
        /// </summary>
        public double CompassTrueHeading
        {
            get { return GetValue<double>(CompassTrueHeadingProperty); }
            set { SetValue(CompassTrueHeadingProperty, value); }
        }

        /// <summary>
        /// Register the CompassTrueHeading property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CompassTrueHeadingProperty = RegisterProperty("CompassTrueHeading", typeof (double));

        /// <summary>
        /// Gets or sets the compass heading accuracy.
        /// </summary>
        public double CompassHeadingAccuracy
        {
            get { return GetValue<double>(CompassHeadingAccuracyProperty); }
            set { SetValue(CompassHeadingAccuracyProperty, value); }
        }

        /// <summary>
        /// Register the CompassHeadingAccuracy property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CompassHeadingAccuracyProperty = RegisterProperty("CompassHeadingAccuracy", typeof (double));
        #endregion

        #region Gyroscope
        /// <summary>
        /// Gets the gyroscope X.
        /// </summary>
        public double GyroscopeX
        {
            get { return GetValue<double>(GyroscopeXProperty); }
            private set { SetValue(GyroscopeXProperty, value); }
        }

        /// <summary>
        /// Register the GyroscopeX property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GyroscopeXProperty = RegisterProperty("GyroscopeX", typeof (double));

        /// <summary>
        /// Gets the gyroscope Y.
        /// </summary>
        public double GyroscopeY
        {
            get { return GetValue<double>(GyroscopeYProperty); }
            private set { SetValue(GyroscopeYProperty, value); }
        }

        /// <summary>
        /// Register the GyroscopeY property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GyroscopeYProperty = RegisterProperty("GyroscopeY", typeof (double));

        /// <summary>
        /// Gets the gyroscope Z.
        /// </summary>
        public double GyroscopeZ
        {
            get { return GetValue<double>(GyroscopeZProperty); }
            private set { SetValue(GyroscopeZProperty, value); }
        }

        /// <summary>
        /// Register the GyroscopeZ property so it is known in the class.
        /// </summary>
        public static readonly PropertyData GyroscopeZProperty = RegisterProperty("GyroscopeZ", typeof (double));
        #endregion

        #region Location
        /// <summary>
        /// Gets or sets the location latitude.
        /// </summary>
        public double LocationLatitude
        {
            get { return GetValue<double>(LocationLatitudeProperty); }
            set { SetValue(LocationLatitudeProperty, value); }
        }

        /// <summary>
        /// Register the LocationLatitude property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LocationLatitudeProperty = RegisterProperty("LocationLatitude", typeof (double));

        /// <summary>
        /// Gets or sets the location longitude.
        /// </summary>
        public double LocationLongitude
        {
            get { return GetValue<double>(LocationLongitudeProperty); }
            set { SetValue(LocationLongitudeProperty, value); }
        }

        /// <summary>
        /// Register the LocationLongitude property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LocationLongitudeProperty = RegisterProperty("LocationLongitude", typeof (double));

        /// <summary>
        /// Gets or sets the location altitude.
        /// </summary>
        public double LocationAltitude
        {
            get { return GetValue<double>(LocationAltitudeProperty); }
            set { SetValue(LocationAltitudeProperty, value); }
        }

        /// <summary>
        /// Register the LocationAltitude property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LocationAltitudeProperty = RegisterProperty("LocationAltitude", typeof (double));
        #endregion

        #endregion

        #endregion

        #region Methods
        /// <summary>
        /// Called when the navigation has completed.
        /// </summary>
        /// <remarks>
        /// This should of course be a cleaner solution, but there is no other way to let a view-model
        /// know that navigation has completed. Another option is injection, but this would require every
        /// view-model for Windows Phone 7 to accept only the navigation context, which has actually nothing
        /// to do with the logic.
        /// <para/>
        /// It is also possible to use the <see cref="NavigationCompleted"/> event.
        /// </remarks>
        protected override void OnNavigationCompleted()
        {
            bool testMode = bool.Parse(NavigationContext["testmode"]);

            if (testMode)
            {
                InitializeTestSensors();
            }
            else
            {
                InitializeRealSensors();
            }

            _accelerometerService.CurrentValueChanged += OnAccelerometerValueChanged;
            _compassService.CurrentValueChanged += OnCompassValueChanged;
            _gyroscopeService.CurrentValueChanged += OnGyroscopeValueChanged;
            _locationService.LocationChanged += OnLocationChanged;

            if (_accelerometerService.IsSupported)
            {
                _accelerometerService.Start();
            }

            if (_compassService.IsSupported)
            {
                _compassService.Start();
            }

            if (_gyroscopeService.IsSupported)
            {
                _gyroscopeService.Start();
            }

            _locationService.Start();
        }

        /// <summary>
        /// Closes this instance. Always called after the <see cref="Cancel"/> of <see cref="Save"/> method.
        /// </summary>
        /// <remarks>
        /// When implementing this method in a base class, make sure to call the base, otherwise <see cref="IsClosed"/> will
        /// not be set to true.
        /// </remarks>
        protected override void Close()
        {
            if (_accelerometerService != null)
            {
                _accelerometerService.Stop();
                _accelerometerService = null;
            }

            if (_compassService != null)
            {
                _compassService.Stop();
                _compassService = null;
            }

            if (_gyroscopeService != null)
            {
                _gyroscopeService.Stop();
                _gyroscopeService = null;
            }

            if (_locationService != null)
            {
                _locationService.Stop();
                _locationService = null;
            }

            base.Close();
        }

        /// <summary>
        /// Initializes the test sensors.
        /// </summary>
        private void InitializeTestSensors()
        {
            ServicesMode = "Test sensors";

            // Normally, you would use IoC container, but because this project uses 
            // test and production instances, they are directly instantiated
            _accelerometerService = new MVVM.Services.Test.AccelerometerService();
            _compassService = new MVVM.Services.Test.CompassService();
            _gyroscopeService = new MVVM.Services.Test.GyroscopeService();
            _locationService = new MVVM.Services.Test.LocationService();

            // In test mode, we need to define the new value when the current one is finished, so do that here
            _accelerometerService.CurrentValueChanged += (sender, e) => EnqueueNextTestDataForAccelerometer();
            _compassService.CurrentValueChanged += (sender, e) => EnqueueNextTestDataForCompass();
            _gyroscopeService.CurrentValueChanged += (sender, e) => EnqueueNextTestDataForGyroscope();
            _locationService.LocationChanged += (sender, e) => EnqueueNextTestDataForLocation();

            EnqueueNextTestDataForAccelerometer();
            EnqueueNextTestDataForCompass();
            EnqueueNextTestDataForGyroscope();
            EnqueueNextTestDataForLocation();
        }

        /// <summary>
        /// Initializes the real sensors.
        /// </summary>
        private void InitializeRealSensors()
        {
            ServicesMode = "Real sensors";

            // Normally, you would use IoC container, but because this project uses 
            // test and production instances, they are directly instantiated
            _accelerometerService = new AccelerometerService();
            _compassService = new CompassService();
            _gyroscopeService = new GyroscopeService();
            _locationService = new LocationService();
        }

        private void OnAccelerometerValueChanged(object sender, AccelerometerValueChangedEventArgs e)
        {
            AccelerometerX = e.Value.X;
            AccelerometerY = e.Value.Y;
            AccelerometerZ = e.Value.Z;
        }

        private void OnCompassValueChanged(object sender, CompassValueChangedEventArgs e)
        {
            CompassMagneticHeading = e.Value.MagneticHeading;
            CompassTrueHeading = e.Value.TrueHeading;
            CompassHeadingAccuracy = e.Value.HeadingAccuracy;
        }

        private void OnGyroscopeValueChanged(object sender, GyroscopeValueChangedEventArgs e)
        {
            GyroscopeX = e.Value.X;
            GyroscopeY = e.Value.Y;
            GyroscopeZ = e.Value.Z;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (e.Location != null)
            {
                LocationLatitude = e.Location.Latitude;
                LocationLongitude = e.Location.Longitude;
                LocationAltitude = e.Location.Altitude;
            }
            else
            {
                LocationLatitude = 0d;
                LocationLongitude = 0d;
                LocationAltitude = 0d;
            }
        }

        private void EnqueueNextTestDataForAccelerometer()
        {
            var testService = (MVVM.Services.Test.AccelerometerService) _accelerometerService;

            Random randomizer = new Random(DateTime.Now.Millisecond);
            var testData = new AccelerometerValue(new DateTimeOffset(DateTime.Now), randomizer.NextDouble(),
                                                  randomizer.NextDouble(), randomizer.NextDouble());
            testService.ExpectedValues.Enqueue(new SensorTestData<IAccelerometerValue>(testData, new TimeSpan(0, 0, 0, 0, 100)));

            if (testService.ExpectedValues.Count <= MinimumTestDataSetCount)
            {
                // Do an additional one
                EnqueueNextTestDataForAccelerometer();
            }
        }

        private void EnqueueNextTestDataForCompass()
        {
            var testService = (MVVM.Services.Test.CompassService) _compassService;

            Random randomizer = new Random(DateTime.Now.Millisecond);
            var testData = new CompassValue(new DateTimeOffset(DateTime.Now), randomizer.NextDouble(),
                                            randomizer.NextDouble(), null, randomizer.NextDouble());
            testService.ExpectedValues.Enqueue(new SensorTestData<ICompassValue>(testData, new TimeSpan(0, 0, 0, 0, 100)));

            if (testService.ExpectedValues.Count <= MinimumTestDataSetCount)
            {
                // Do an additional one
                EnqueueNextTestDataForCompass();
            }
        }

        private void EnqueueNextTestDataForGyroscope()
        {
            var testService = (MVVM.Services.Test.GyroscopeService) _gyroscopeService;

            Random randomizer = new Random(DateTime.Now.Millisecond);
            var testData = new GyroscopeValue(new DateTimeOffset(DateTime.Now), randomizer.NextDouble(),
                                              randomizer.NextDouble(), randomizer.NextDouble());
            testService.ExpectedValues.Enqueue(new SensorTestData<IGyroscopeValue>(testData, new TimeSpan(0, 0, 0, 0, 100)));

            if (testService.ExpectedValues.Count <= MinimumTestDataSetCount)
            {
                // Do an additional one
                EnqueueNextTestDataForGyroscope();
            }
        }

        private void EnqueueNextTestDataForLocation()
        {
            var testService = (MVVM.Services.Test.LocationService) _locationService;

            Random randomizer = new Random(DateTime.Now.Millisecond);
            var testData = new Location(randomizer.NextDouble(), randomizer.NextDouble(), randomizer.NextDouble());
            testService.ExpectedLocations.Enqueue(new LocationTestData(testData, new TimeSpan(0, 0, 0, 0, 100)));

            if (testService.ExpectedLocations.Count <= MinimumTestDataSetCount)
            {
                // Do an additional one
                EnqueueNextTestDataForLocation();
            }
        }
        #endregion
    }
}