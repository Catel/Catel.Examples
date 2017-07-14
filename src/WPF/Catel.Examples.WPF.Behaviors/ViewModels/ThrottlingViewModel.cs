// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrottlingViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Behaviors.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Threading;
    using Data;
    using MVVM;

    public class ThrottlingViewModel : ViewModelBase
    {
        #region Constants
        /// <summary>
        /// Register the FrameRate property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FrameRateProperty = RegisterProperty("FrameRate", typeof(int), 0);

        /// <summary>
        /// Register the Counter property so it is known in the class.
        /// </summary>
        public static readonly PropertyData CounterProperty = RegisterProperty("Counter", typeof(int), 0);

        /// <summary>
        /// Register the Throttling property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ThrottlingProperty = RegisterProperty("Throttling", typeof(int), 0,
            (sender, e) => ((ThrottlingViewModel) sender).OnThrottlingChanged());
        #endregion

        #region Fields
        private readonly DispatcherTimer _counterTimer = new DispatcherTimer();
        private readonly DispatcherTimer _frameRateTimer = new DispatcherTimer();
        private int _frameRateCounter;
        #endregion

        #region Properties
        public override string Title
        {
            get { return "Throttling example"; }
        }

        /// <summary>
        /// Gets or sets the frame rate.
        /// </summary>
        public int FrameRate
        {
            get { return GetValue<int>(FrameRateProperty); }
            set { SetValue(FrameRateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the counter.
        /// </summary>
        public int Counter
        {
            get { return GetValue<int>(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the throttling in milliseconds.
        /// </summary>
        public int Throttling
        {
            get { return GetValue<int>(ThrottlingProperty); }
            set { SetValue(ThrottlingProperty, value); }
        }
        #endregion

        #region Methods
        private void OnThrottlingChanged()
        {
            ThrottlingRate = new TimeSpan(0, 0, 0, 0, Throttling);
        }

        protected override async Task InitializeAsync()
        {
            _frameRateTimer.Interval = new TimeSpan(0, 0, 0, 1);
            _frameRateTimer.Tick += (sender, e) => OnFrameRateCounterElapsed();
            _frameRateTimer.Start();

            _counterTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _counterTimer.Tick += (sender, e) => OnCounterTimerElapsed();
            _counterTimer.Start();

            CompositionTarget.Rendering += OnRendering;
        }

        private void OnRendering(object sender, EventArgs e)
        {
            _frameRateCounter++;
        }

        private void OnFrameRateCounterElapsed()
        {
            FrameRate = _frameRateCounter;
            _frameRateCounter = 0;
        }

        private void OnCounterTimerElapsed()
        {
            Counter++;
        }

        protected override async Task CloseAsync()
        {
            _counterTimer.Stop();
        }
        #endregion
    }
}