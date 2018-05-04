// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MultiLingual.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Catel.Services;
    using Models;
    using MVVM;
    using System.Threading.Tasks;

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private readonly ILanguageService _languageService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IUIVisualizerService _uiVisualizerService;
        #endregion

        #region Constructors
        public MainViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService,
            ILanguageService languageService)
        {
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => pleaseWaitService);
            Argument.IsNotNull(() => languageService);

            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _languageService = languageService;

            AvailableLanguages = new ObservableCollection<Language>();
            AvailableLanguages.Add(new Language("English", "en-US"));
            AvailableLanguages.Add(new Language("Chinese (simplified)", "zh-HANS"));
            AvailableLanguages.Add(new Language("Dutch", "nl"));
            AvailableLanguages.Add(new Language("French", "fr"));
            AvailableLanguages.Add(new Language("German", "de"));
            AvailableLanguages.Add(new Language("Spanish", "es"));
            AvailableLanguages.Add(new Language("Turkish", "tr"));

            var currentLanguage = (from language in AvailableLanguages
                                   where Thread.CurrentThread.CurrentUICulture.Name.StartsWith(language.Code)
                                   select language).FirstOrDefault();

            SelectedLanguage = currentLanguage ?? AvailableLanguages[0];

            DataWindow = new TaskCommand(OnDataWindowExecuteAsync);

            Title = "MultiLingual example";
        }
        #endregion

        #region Properties
        public ObservableCollection<Language> AvailableLanguages { get; set; }

        public Language SelectedLanguage { get; set; }
        #endregion

        #region Commands
        public TaskCommand DataWindow { get; private set; }

        private async Task OnDataWindowExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<DataWindowViewModel>(new Language());
        }
        #endregion

        #region Methods
        private void OnSelectedLanguageChanged()
        {
            if (SelectedLanguage != null)
            {
                var newCulture = new CultureInfo(SelectedLanguage.Code);

                Thread.CurrentThread.CurrentUICulture = newCulture;
                _languageService.PreferredCulture = newCulture;
            }
        }
        #endregion
    }
}