using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayZ_DrJonesToExpansionMarket
{
    public partial class ExpansionTraderConfig
    {
        [JsonProperty("m_Version", NullValueHandling = NullValueHandling.Ignore)]
        public long? MVersion { get; set; }

        [JsonProperty("TraderName", NullValueHandling = NullValueHandling.Ignore)]
        public string TraderName { get; set; }

        [JsonProperty("DisplayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("TraderIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string TraderIcon { get; set; }

        [JsonProperty("Currencies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Currencies { get; set; }

        [JsonProperty("Categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Categories { get; set; }

        [JsonProperty("Items", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Items { get; set; }
    }
}
