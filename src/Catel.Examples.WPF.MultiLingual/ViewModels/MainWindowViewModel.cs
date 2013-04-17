namespace Catel.Examples.WPF.MultiLingual.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Catel.MVVM;
    using Data;
    using MVVM.Services;
    using Models;
    using Windows;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
            : base()
        {
            AvailableLanguages = new ObservableCollection<Language>();
            AvailableLanguages.Add(new Language("English", "en-US"));
            AvailableLanguages.Add(new Language("Chinese (simplified)", "zh-CHS"));
            AvailableLanguages.Add(new Language("Dutch", "nl"));
            AvailableLanguages.Add(new Language("French", "fr"));
            AvailableLanguages.Add(new Language("German", "de"));
            AvailableLanguages.Add(new Language("Spanish", "es"));
            AvailableLanguages.Add(new Language("Turkish", "tr"));

            var currentLanguage = (from language in AvailableLanguages
                                   where Thread.CurrentThread.CurrentUICulture.Name.StartsWith(language.Code)
                                   select language).FirstOrDefault();

            SelectedLanguage = currentLanguage ?? AvailableLanguages[0];

            DataWindow = new Command(OnDataWindowExecute);
            PleaseWaitWindow = new Command(OnPleaseWaitWindowExecute);
            MultipleChoiceWindow = new Command(OnMultipleChoiceWindowExecute);
            MultiLineInput = new Command(OnMultiLineInputExecute);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Multilingual example"; } }

        /// <summary>
        /// Gets or sets the available languages.
        /// </summary>
        public ObservableCollection<Language> AvailableLanguages
        {
            get { return GetValue<ObservableCollection<Language>>(AvailableLanguagesProperty); }
            set { SetValue(AvailableLanguagesProperty, value); }
        }

        /// <summary>
        /// Register the AvailableLanguages property so it is known in the class.
        /// </summary>
        public static readonly PropertyData AvailableLanguagesProperty = RegisterProperty("AvailableLanguages", typeof(ObservableCollection<Language>));

        /// <summary>
        /// Gets or sets the selected language.
        /// </summary>
        public Language SelectedLanguage
        {
            get { return GetValue<Language>(SelectedLanguageProperty); }
            set { SetValue(SelectedLanguageProperty, value); }
        }

        /// <summary>
        /// Register the SelectedLanguage property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedLanguageProperty = RegisterProperty("SelectedLanguage", typeof(Language), null,
            (sender, e) => ((MainWindowViewModel)sender).OnSelectedLanguageChanged());
        #endregion

        #region Commands
        /// <summary>
        /// Gets the DataWindow command.
        /// </summary>
        public Command DataWindow { get; private set; }

        /// <summary>
        /// Method to invoke when the DataWindow command is executed.
        /// </summary>
        private void OnDataWindowExecute()
        {
            var vm = new DataWindowViewModel(new Language());
            GetService<IUIVisualizerService>().ShowDialog(vm);
        }

        /// <summary>
        /// Gets the PleaseWaitWindow command.
        /// </summary>
        public Command PleaseWaitWindow { get; private set; }

        /// <summary>
        /// Method to invoke when the PleaseWaitWindow command is executed.
        /// </summary>
        private void OnPleaseWaitWindowExecute()
        {
            var pleaseWaitService = GetService<IPleaseWaitService>();
            pleaseWaitService.Show(() => Thread.Sleep(3000));
        }

        /// <summary>
        /// Gets the MultipleChoiceWindow command.
        /// </summary>
        public Command MultipleChoiceWindow { get; private set; }

        /// <summary>
        /// Method to invoke when the MultipleChoiceWindow command is executed.
        /// </summary>
        private void OnMultipleChoiceWindowExecute()
        {
            // TODO: not really MVVM
            var choices = new List<Choice>()
            {
                new Choice("Choice 1", "My choice 1"),
                new Choice("Choice 2", "My choice 2"),
                new Choice("Choice 3", "My choice 3"),
            };

            var choiceWindow = new MultipleChoiceWindow(choices);
            choiceWindow.ShowDialog();
        }

        /// <summary>
        /// Gets the MultiLineInput command.
        /// </summary>
        public Command MultiLineInput { get; private set; }

        /// <summary>
        /// Method to invoke when the MultiLineInput command is executed.
        /// </summary>
        private void OnMultiLineInputExecute()
        {
            var multiLineInput = new MultiLineInputWindow();
            multiLineInput.ShowDialog();
        }
        #endregion

        #region Methods
        private void OnSelectedLanguageChanged()
        {
            if (SelectedLanguage != null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedLanguage.Code);
            }
        }
        #endregion
    }
}
