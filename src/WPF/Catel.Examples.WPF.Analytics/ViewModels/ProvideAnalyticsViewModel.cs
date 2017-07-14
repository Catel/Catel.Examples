// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProvideAnalyticsViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Analytics.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Data;
    using MVVM;

    public class ProvideAnalyticsViewModel : ViewModelBase
    {
        #region Constructors
        public ProvideAnalyticsViewModel()
        {
            Title = "Provide google analytics info";
        }
        #endregion

        #region Properties
        [DefaultValue("UA-25600919-2")]
        public string ApiKey { get; set; }
        #endregion

        #region Methods
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(ApiKey), "Api key is required"));
            }
        }
        #endregion
    }
}