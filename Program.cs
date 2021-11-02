using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayZ_DrJonesToExpansionMarket
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var pathToInputFile = args[0];
            var inputFileContent = await File.ReadAllLinesAsync(pathToInputFile);

            var items = new List<Item>();
            var trader = new ExpansionTraderConfig
            {
                Items = new Dictionary<string, long>()
            };


            foreach (var line in inputFileContent)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (line.Contains("/")) continue;
                if (line.Contains("<Trader>")) continue;
                if (line.Contains("<Category>")) continue;

                var itemValues = line.Replace("\t", string.Empty)
                    .Replace(" ", string.Empty)
                    .Split(",");

                if (itemValues.Length != 4) continue;

                items.Add(new Item
                {
                    ClassName = itemValues[0],
                    MaxPriceThreshold = int.Parse(itemValues[2]),
                    MaxStockThreshold = 100, //add config
                    MinPriceThreshold = int.Parse(itemValues[2]),
                    MinStockThreshold = 1,
                    PurchaseType = 0,
                    SpawnAttachments = new List<string>(),
                    Variants = new List<string>()
                });

                if (trader.Items.Keys.Contains($"{itemValues[0]}")) continue;
                trader.Items.Add($"{itemValues[0]}", 1);
            }

            var exportMarketConfig = new ExpansionMarketConfig
            {
                DisplayName = $"expansion_{Path.GetFileNameWithoutExtension(args[0])}",
                Items = items,
                MVersion = 4
            };

            var exportTraderConfig = new ExpansionTraderConfig
            {
                MVersion = 7,
                TraderName = "REPLACE ME",
                DisplayName = $"expansion_{Path.GetFileNameWithoutExtension(args[0])}",
                TraderIcon = "REPLACE ME",
                Currencies = new List<string>(),
                Categories = new List<object>(),
                Items = trader.Items
            };

            await File.WriteAllTextAsync($"expansionMarketConfig_{Path.GetFileNameWithoutExtension(args[0])}.json", JsonConvert.SerializeObject(exportMarketConfig, Formatting.Indented));
            await File.WriteAllTextAsync($"expansionTraderConfig_{Path.GetFileNameWithoutExtension(args[0])}.json", JsonConvert.SerializeObject(exportTraderConfig, Formatting.Indented));
        }
    }
}
