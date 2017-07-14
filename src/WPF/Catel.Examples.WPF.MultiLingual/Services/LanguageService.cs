// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="Catel development team">
//   Copyright (c) 2008 - 2014 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WPF.MultiLingual.Services
{
    using System.Globalization;
    using Catel.Services;

    public class LanguageService : Catel.Services.LanguageService
    {
        #region Methods
        protected override string GetString(ILanguageSource languageSource, string resourceName, CultureInfo cultureInfo)
        {
            if (string.Equals(resourceName, "DynamicResource"))
            {
                return string.Format("Dynamic resource in '{0}'", cultureInfo);
            }

            return base.GetString(languageSource, resourceName, cultureInfo);
        }
        #endregion
    }
}