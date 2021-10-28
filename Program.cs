using System;
using System.Collections.Generic;
using System.IO;
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
            }

            var export = new ExpansionMarketConfig
            {
                DisplayName = $"expansion_{Path.GetFileNameWithoutExtension(args[0])}",
                Items = items,
                MVersion = 4
            };

            await File.WriteAllTextAsync($"expansion_{Path.GetFileNameWithoutExtension(args[0])}.json", JsonConvert.SerializeObject(export, Formatting.Indented));
        }
    }
}
