﻿namespace Catel.Examples.DisplayProgress.ViewModels
{
#if SILVERLIGHT
    using System.ComponentModel;
#endif

    using System.Threading;
    using MVVM;
    using Services;
    using MVVM.Tasks;

    /// <summary>
    ///     The main window view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly ISplashScreenService _splashScreenService;

        #region Fields
        /// <summary>
        ///     The click.
        /// </summary>
        private int click;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="pleaseWaitService">The please wait service.</param>
        /// <param name="splashScreenService"></param>
        public MainWindowViewModel(IPleaseWaitService pleaseWaitService, ISplashScreenService splashScreenService)
        {
            _pleaseWaitService = pleaseWaitService;
            _splashScreenService = splashScreenService;

            IndeterminateCommand = new Command(IndeterminateCommandExecute);
            ShowProgressCommand = new Command(ShowProgressCommandExecute);
            ShowProgressWithSplashScreenCommand = new Command(ShowProgressWithSplashScreenCommandExecute);
            ShowProgressWithSplashScreenDetailedCommand = new Command(ShowProgressWithSplashScreenDetailedCommandExecute);
            ShowProgressInRegionCommand = new Command(ShowProgressInRegionCommandExecute);
            ShowProgressWithSplashScreenMoreDetailedCommand = new Command(ShowProgressWithSplashScreenMoreDetailedCommandExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the indeterminate command.
        /// </summary>
        public Command IndeterminateCommand { get; private set; }

        /// <summary>
        ///     Gets the show progress command.
        /// </summary>
        public Command ShowProgressCommand { get; private set; }

        /// <summary>
        ///     Gets the show progress in region command.
        /// </summary>
        public Command ShowProgressInRegionCommand { get; private set; }

        /// <summary>
        ///     Gets the show progress with splash screen command.
        /// </summary>
        public Command ShowProgressWithSplashScreenCommand { get; private set; }

        /// <summary>
        ///     Gets the show progress with splash screen detailed command.
        /// </summary>
        public Command ShowProgressWithSplashScreenDetailedCommand { get; private set; }

        /// <summary>
        ///     Gets the show progress with splash screen more detailed command.
        /// </summary>
        public Command ShowProgressWithSplashScreenMoreDetailedCommand { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// The register detailed task.
        /// </summary>
        /// <param name="splashScreenService">
        /// The splash screen service.
        /// </param>
        private static void RegisterDetailedTask(ISplashScreenService splashScreenService)
        {
            splashScreenService.Enqueue(new ActionTask("Setting up enviroment", tracker =>
                {
                    tracker.UpdateStatus("Loading dictionaries...");
                    Thread.Sleep(3000);
                    tracker.UpdateStatus("Locating fake files...");
                    Thread.Sleep(3000);
                    tracker.UpdateStatus("Almost ready, wait for it....", 98);
                    Thread.Sleep(3000);
                    tracker.UpdateStatus("Sorry, you have to wait more....", true);
                    Thread.Sleep(3000);
                }));

            splashScreenService.Enqueue(new ActionTask("Linking to Satelite", tracker =>
                {
                    tracker.UpdateStatus("Step 1", 25);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 2", 50);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 3", 75);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 4", 100);
                }));

            splashScreenService.Enqueue(new ActionTask("Downloading original files from NASA servers", tracker =>
                {
                    tracker.UpdateStatus("Step 1", 25);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 2", 50);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 3", 75);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 4", 100);
                }));

            splashScreenService.Enqueue(new ActionTask("Replacing original files with fake ones", tracker =>
                {
                    tracker.UpdateStatus("Step 1", 25);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 2", 50);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 3", 75);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 4", 100);
                }));

            splashScreenService.Enqueue(new ActionTask("Closing satellite connections", tracker =>
                {
                    tracker.UpdateStatus("Step 1", 25);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 2", 50);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 3", 75);
                    Thread.Sleep(1000);
                    tracker.UpdateStatus("Step 4", 100);
                }));
        }

        /// <summary>
        /// The register task.
        /// </summary>
        /// <param name="splashScreenService">
        /// The splash screen service.
        /// </param>
        private static void RegisterTask(ISplashScreenService splashScreenService)
        {
            splashScreenService.Enqueue(new ActionTask("Linking to Satelite", delegate { Thread.Sleep(1000); }));
            splashScreenService.Enqueue(new ActionTask("Downloading original files from NASA servers", delegate { Thread.Sleep(1000); }));
            splashScreenService.Enqueue(new ActionTask("Replacing original files with fake ones", delegate { Thread.Sleep(1000); }));
            splashScreenService.Enqueue(new ActionTask("Closing satellite connections", delegate { Thread.Sleep(1000); }));
        }

        /// <summary>
        ///     The indeterminate command execute.
        /// </summary>
        private void IndeterminateCommandExecute()
        {
#if SILVERLIGHT
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) => Thread.Sleep(5000);
            backgroundWorker.RunWorkerAsync();
            backgroundWorker.RunWorkerCompleted += (sender, args) => _pleaseWaitService.Hide();
            _pleaseWaitService.Show("There is a lot of work to do and don't know when will be done...");
#else
            _pleaseWaitService.Show(() => Thread.Sleep(5000), "There is a lot of work to do and don't know when will be done...");
#endif
        }

        /// <summary>
        ///     The show progress command execute.
        /// </summary>
        private void ShowProgressCommandExecute()
        {
            RegisterTask(_splashScreenService);

            _splashScreenService.CommitAsync();
        }

        /// <summary>
        ///     The show progress in region command execute.
        /// </summary>
        private void ShowProgressInRegionCommandExecute()
        {
            var progressControlViewModel = new CustomProgressControlViewModel();

            RegisterDetailedTask(_splashScreenService);

            _splashScreenService.CommitAsync(progressControlViewModel, this, string.Format("ProgressRegion{0}", (click++) % 2));
        }

        /// <summary>
        ///     The show progress with splash screen command execute.
        /// </summary>
        private void ShowProgressWithSplashScreenCommandExecute()
        {
            RegisterTask(_splashScreenService);

            _splashScreenService.CommitAsync<SplashScreenWindowViewModel>();
        }

        /// <summary>
        ///     The show progress with splash screen detailed command execute.
        /// </summary>
        private void ShowProgressWithSplashScreenDetailedCommandExecute()
        {
            RegisterDetailedTask(_splashScreenService);

            _splashScreenService.CommitAsync<SplashScreen1WindowViewModel>();
        }

        /// <summary>
        ///     The show progress with splash screen more detailed command execute.
        /// </summary>
        private void ShowProgressWithSplashScreenMoreDetailedCommandExecute()
        {
            RegisterDetailedTask(_splashScreenService);
            _splashScreenService.CommitAsync<SplashScreen2WindowViewModel>();
        }
        #endregion
    }
}