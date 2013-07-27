namespace Catel.Examples.WPF.Analytics.ViewModels
{
    using System.Collections.Generic;
    using Data;
    using MVVM;

    /// <summary>
    /// ProvideAnalytics view model.
    /// </summary>
    public class ProvideAnalyticsViewModel : ViewModelBase
    {
        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvideAnalyticsViewModel"/> class.
        /// </summary>
        public ProvideAnalyticsViewModel()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Provide google analytics info"; } }

        /// <summary>
        /// Gets or sets the google analytics api key.
        /// </summary>
        public string ApiKey
        {
            get { return GetValue<string>(ApiKeyProperty); }
            set { SetValue(ApiKeyProperty, value); }
        }

        /// <summary>
        /// Register the ApiKey property so it is known in the class.
        /// </summary>
        public static readonly PropertyData ApiKeyProperty = RegisterProperty("ApiKey", typeof(string), "UA-25600919-2");
        #endregion

        #region Commands
        #endregion

        #region Methods
        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                validationResults.Add(FieldValidationResult.CreateError(ApiKeyProperty, "Api key is required"));
            }
        }
        #endregion
    }
}
