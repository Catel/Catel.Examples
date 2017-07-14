﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MultiLingual.Services
{
    using System.Globalization;
    using Catel.Services;

    public class LanguageService : Catel.Services.LanguageService
    {
        #region Methods
        public override string GetString(ILanguageSource languageSource, string resourceName, CultureInfo cultureInfo)
        {
            if (string.Equals(resourceName, "DynamicResource"))
            {
                return $"Dynamic resource in '{cultureInfo}'";
            }

            return base.GetString(languageSource, resourceName, cultureInfo);
        }
        #endregion
    }
}