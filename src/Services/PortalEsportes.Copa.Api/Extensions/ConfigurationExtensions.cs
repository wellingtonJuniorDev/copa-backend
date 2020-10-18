using Microsoft.Extensions.Configuration;
using System;

namespace PortalEsportes.Copa.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T SafeGet<T>(this IConfiguration configuration, string sectionName)
        {
            var appSettingsSection = configuration.GetSection(sectionName);
            var appSettingsSectionSettings = appSettingsSection.Get<T>();
            
            if (appSettingsSectionSettings is null)
            {
                throw new ArgumentNullException($"Configuração {sectionName} não encontrada nas variáveis de ambiente");
            }

            return appSettingsSectionSettings;
        }
    }
}
