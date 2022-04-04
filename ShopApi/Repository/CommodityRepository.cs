using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ShopApi.Models;

namespace ShopApi.Repository
{
    public class CommodityRepository : ICommodityRepository
    {
        private const string DbRootPath = @"./DB/Commodities";
        public async Task<Commodity> GetCommodity(string name)
        {
            var path = $@"{DbRootPath}/{name}/value.json";
            using StreamReader file = new(path);
            var json = await file.ReadToEndAsync();
            var commodityValue = JsonSerializer.Deserialize<CommodityValue>(json)
                            ?? throw new Exception($"{path} json value deserialize Commodity Fail.");

            var imgNames = new DirectoryInfo($@"{DbRootPath}/{name}/img")
                .GetFiles("*.jpg")
                .Select(fi => fi.Name)
                .ToList();

            var commodity = new Commodity
            {
                Name = commodityValue.Name,
                Price = commodityValue.Price,
                Comment = commodityValue.Comment,
                Images = new List<string>()
            };

            foreach (var imgName in imgNames)
            {
                var image =
                    await File.ReadAllBytesAsync($@"{DbRootPath}/{name}/img/{imgName}");
                commodity.Images.Add(Convert.ToBase64String(image));
            }

            return commodity;
        }

        public async Task<List<Commodity>> GetCommodities()
        {
            var commodities = new List<Commodity>();

            var commoditiesName = new DirectoryInfo(DbRootPath)
                .GetDirectories("")
                .Select(fi => fi.Name);

            foreach (var commodityName in commoditiesName)
            {
                var commodity = await GetCommodity(commodityName);
                commodities.Add(commodity);
            }

            return commodities;
        }
    }
}
