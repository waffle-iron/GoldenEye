using System;
using Microsoft.Extensions.Configuration;

namespace GoldenEye.Shared.Core.ConfigurationHelper
{
    /// <summary>
    /// Configuration Manager not exists in net core 
    /// Need to be fixed with:
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
    /// </summary>
    public class ConfigHelper
    {
        public static bool IsInTestMode
        {
            get
            {
                return GetSettingAsString("IsInTestMode") == "true";
            }
        }

        /// <summary>
        /// Returns the value of the configuration setting called ”settingName”
        /// from either web.config, or the Azure Role Environment.
        /// </summary>
        public static string GetSettingAsString(string settingName)
        {
            throw new NotImplementedException();
            //    if (RoleEnvironment.IsAvailable)
            //        return RoleEnvironment.GetConfigurationSettingValue(settingName);

            //if (Configuration[settingName] != null)
            //    return ConfigurationManager.AppSettings[settingName];

            //return ConfigurationManager.ConnectionStrings[settingName] != null
            //         ? ConfigurationManager.ConnectionStrings[settingName].ConnectionString
            //         : null;
        }
    }
}