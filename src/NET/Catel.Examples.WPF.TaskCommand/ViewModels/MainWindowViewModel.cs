// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Taggersoft">
//   Copyright (c) 2008 - 2013 Taggersoft. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Examples.WPF.TaskCommand.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using Catel.Data;
    using Catel.MVVM;

    public class MainWindowViewModel : ViewModelBase
    {
        #region LoadSomething command

        private ProgressiveTaskCommand<PercentProgress> _loadSomethingCommand;

        /// <summary>
        ///     Gets the LoadSomething command.
        /// </summary>
        public ProgressiveTaskCommand<PercentProgress> LoadSomethingCommand
        {
            get
            {
                return _loadSomethingCommand ??
                       (_loadSomethingCommand =
                           new ProgressiveTaskCommand<PercentProgress>(LoadSomething, reportProgress: ReportLoadSomethingProgress));
            }
        }

        private void ReportLoadSomethingProgress(PercentProgress progress)
        {
            LoadPercents = progress.Percents;
            StatusText = progress.Status;
        }

        /// <summary>
        ///     Method to invoke when the LoadSomething command is executed.
        /// </summary>
        private static async Task LoadSomething(CancellationToken cancellationToken, IProgress<PercentProgress> progress)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool isCanceled = false;
            int percents = 0;
            try
            {
                var rnd = new Random();
                bool fast = rnd.Next(0, 10) > 5;
                for (percents = 0; percents < 100; percents++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Reporting progress.
                    progress.Report(new PercentProgress(percents, string.Format("Loading [{0}%]...", percents)));

                    // Simulating a long running process.
                    int delayMilliseconds = rnd.Next(percents, percents + 50) < 50 || percents > 90
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
                progress.Report(
                    new PercentProgress(
                        percents,
                        isCanceled ?
                        string.Format("Loaded {0:D}%. Canceled after {1:F2}s.", percents, sw.Elapsed.TotalSeconds) :
                        string.Format("Loaded {0:D}% in {1:F2}s.", percents, sw.Elapsed.TotalSeconds)));
            }
        }

        #endregion

        #region LoadPercents property

        /// <summary>
        ///     LoadPercents property data.
        /// </summary>
        public static readonly PropertyData LoadPercentsProperty = RegisterProperty("LoadPercents", typeof(int));

        /// <summary>
        ///     Gets or sets the LoadPercents value.
        /// </summary>
        public int LoadPercents
        {
            get { return GetValue<int>(LoadPercentsProperty); }
            set { SetValue(LoadPercentsProperty, value); }
        }

        #endregion

        #region StatusText property

        /// <summary>
        ///     StatusText property data.
        /// </summary>
        public static readonly PropertyData StatusTextProperty = RegisterProperty("StatusText", typeof(string));

        /// <summary>
        ///     Gets or sets the StatusText value.
        /// </summary>
        public string StatusText
        {
            get { return GetValue<string>(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        #endregion
    }

    public class PercentProgress : ITaskProgressReport
    {
        public PercentProgress(int percents, string status = null)
        {
            Percents = percents;
            Status = status;
        }

        public int Percents { get; private set; }

        #region ITaskProgressReport Members

        public string Status { get; private set; }

        #endregion
    }
}