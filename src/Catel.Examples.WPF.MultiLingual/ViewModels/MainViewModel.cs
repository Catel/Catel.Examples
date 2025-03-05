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
    using System;

    public class MainViewModel : ViewModelBase
    {
        private readonly ILanguageService _languageService;
        private readonly IBusyIndicatorService _busyIndicatorService;
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainViewModel(IUIVisualizerService uiVisualizerService, IBusyIndicatorService busyIndicatorService,
            ILanguageService languageService)
        {
            ArgumentNullException.ThrowIfNull(uiVisualizerService);
            ArgumentNullException.ThrowIfNull(busyIndicatorService);
            ArgumentNullException.ThrowIfNull(languageService);

            _uiVisualizerService = uiVisualizerService;
            _busyIndicatorService = busyIndicatorService;
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

        public ObservableCollection<Language> AvailableLanguages { get; set; }

        public Language SelectedLanguage { get; set; }

        public TaskCommand DataWindow { get; private set; }

        private async Task OnDataWindowExecuteAsync()
        {
            await _uiVisualizerService.ShowDialogAsync<DataWindowViewModel>(new Language());
        }

        private void OnSelectedLanguageChanged()
        {
            if (SelectedLanguage is not null)
            {
                var newCulture = new CultureInfo(SelectedLanguage.Code);

                Thread.CurrentThread.CurrentUICulture = newCulture;
                _languageService.PreferredCulture = newCulture;
            }
        }
    }
}
