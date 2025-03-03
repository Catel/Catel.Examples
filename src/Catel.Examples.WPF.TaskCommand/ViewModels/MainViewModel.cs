namespace Catel.Examples.TaskCommand.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        #region Constructors
        public MainViewModel()
        {
            LoadSomethingCommand = new ProgressiveTaskCommand<PercentProgress>(LoadSomethingAsync, reportProgress: ReportLoadSomethingProgress);

            Title = "Task command example";
        }
        #endregion

        #region Properties
        public int LoadPercent { get; set; }

        public string StatusText { get; set; }
        #endregion

        #region Commands
        public ProgressiveTaskCommand<PercentProgress> LoadSomethingCommand { get; private set; }

        private static async Task LoadSomethingAsync(CancellationToken cancellationToken, IProgress<PercentProgress> progress)
        {
            var sw = Stopwatch.StartNew();
            var isCanceled = false;
            var percent = 0;

            try
            {
                var rnd = new Random();
                var fast = rnd.Next(0, 10) > 5;

                for (percent = 0; percent < 100; percent++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Reporting progress.
                    progress.Report(new PercentProgress(percent, string.Format("Loading [{0}%]...", percent)));

                    // Simulating a long running process.
                    var delayMilliseconds = rnd.Next(percent, percent + 50) < 50 || percent > 90
                        ? rnd.Next(fast ? 1 : 100, fast ? 10 : 500)
                        : rnd.Next(10, 100);

                    await Task.Delay(delayMilliseconds, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                isCanceled = true;
            }
            finally
            {
                sw.Stop();

                // Reporting progress.
                progress.Report(new PercentProgress(percent, isCanceled ? string.Format("Loaded {0:D}%. Canceled after {1:F2}s.", percent, sw.Elapsed.TotalSeconds) : string.Format("Loaded {0:D}% in {1:F2}s.", percent, sw.Elapsed.TotalSeconds)));
            }
        }

        private void ReportLoadSomethingProgress(PercentProgress progress)
        {
            LoadPercent = progress.Percent;
            StatusText = progress.Status;
        }
        #endregion
    }
}
