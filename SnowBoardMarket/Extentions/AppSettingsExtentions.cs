using SnowBoardMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowBoardMarket.Extentions
{
    public static class AppSettingsExtentions
    {
        public static string GetAppUri(this AppSettings appSettings)
        {
            if (appSettings.EnableSSl)
            {
                return $"https://{appSettings.Domain}";
            }
            else
            {
                return $"http://{appSettings.Domain}";
            }
        }
    }
}
