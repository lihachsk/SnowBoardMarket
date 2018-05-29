using SnowBoardMarket.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowBoardMarket.Models
{
    public class AppSettings
    {
        public bool EnableSSl { get; set; }

        public string Domain { get; set; }
        public string DomainUri
        {
            get
            {
                return this.GetAppUri();
            }
        }
        public string BasketUri { get; set; }
    }
}
