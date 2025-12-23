namespace Catel.Examples.MultiLingual.Services
{
    using System.Globalization;
    using Catel.Services;
    using Microsoft.Extensions.Logging;

    public class LanguageService : Catel.Services.LanguageService
    {
        public LanguageService(ILogger<Catel.Services.LanguageService> logger)
            : base(logger)
        {
            
        }

        public override string GetString(ILanguageSource languageSource, string resourceName, CultureInfo cultureInfo)
        {
            if (string.Equals(resourceName, "DynamicResource"))
            {
                return $"Dynamic resource in '{cultureInfo}'";
            }

            return base.GetString(languageSource, resourceName, cultureInfo);
        }
    }
}
