namespace Catel.Examples.WPF.MultiLingual.ViewModels
{
    using System;
    using Catel.MVVM;
    using Data;
    using Models;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class DataWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataWindowViewModel"/> class.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="language"/> is <c>null</c>.</exception>
        public DataWindowViewModel(Language language)
        {
            Argument.IsNotNull("language", language);

            Language = language;
        }

        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Data Window Demo"; } }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [Model]
        [Fody.Expose("Name")]
        [Fody.Expose("Code")]
        private Language Language
        {
            get { return GetValue<Language>(LanguageProperty); }
            set { SetValue(LanguageProperty, value); }
        }

        /// <summary>
        /// Register the Language property so it is known in the class.
        /// </summary>
        public static readonly PropertyData LanguageProperty = RegisterProperty("Language", typeof(Language));
    }
}
