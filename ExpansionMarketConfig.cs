using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayZ_DrJonesToExpansionMarket
{
    public partial class ExpansionMarketConfig
    {
        [JsonProperty("m_Version", NullValueHandling = NullValueHandling.Ignore)]
        public long? MVersion { get; set; }

        [JsonProperty("DisplayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("Items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("ClassName", NullValueHandling = NullValueHandling.Ignore)]
        public string ClassName { get; set; }

        [JsonProperty("MaxPriceThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxPriceThreshold { get; set; }

        [JsonProperty("MinPriceThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinPriceThreshold { get; set; }

        [JsonProperty("MaxStockThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxStockThreshold { get; set; }

        [JsonProperty("MinStockThreshold", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinStockThreshold { get; set; }

        [JsonProperty("PurchaseType", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseType { get; set; }

        [JsonProperty("SpawnAttachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> SpawnAttachments { get; set; }

        [JsonProperty("Variants", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Variants { get; set; }
    }
}
