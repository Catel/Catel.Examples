namespace Catel.Examples.ViewModelThrottling.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Threading;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        private readonly DispatcherTimer _counterTimer = new DispatcherTimer();
        private readonly DispatcherTimer _frameRateTimer = new DispatcherTimer();

        private int _frameRateCounter;

        public MainViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Title = "View Model Throttling example";
        }

        public int FrameRate { get; set; }

        public int Counter { get; set; }

        public int Throttling { get; set; }

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

        protected override async Task CloseAsync()
        {
            CompositionTarget.Rendering -= OnRendering;

            _counterTimer.Stop();
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
    }
}
