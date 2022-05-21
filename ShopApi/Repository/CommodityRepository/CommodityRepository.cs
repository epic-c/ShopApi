using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ShopApi.Models.Commodity;

namespace ShopApi.Repository.CommodityRepository
{
    public class CommodityRepository : ICommodityRepository
    {
        private const string DbRootPath = @"./DB/Commodities";
        public async Task<Commodity> GetCommodityAndAllImage(string id) =>
            new(await GetCommodityValue(id))
            {
                Images = await GetAllImages(
                    id,
                    new DirectoryInfo($@"{DbRootPath}/{id}/img")
                        .GetFiles("*.jpg")
                        .Select(fi => fi.Name)
                        .ToList())
            };

        public async Task<List<Commodity>> GetCommodities()
        {
            var ids = new DirectoryInfo(DbRootPath)
                .GetDirectories(string.Empty)
                .Select(fi => fi.Name);

            var commodities = new List<Commodity>();
            foreach (var id in ids)
            {
                commodities.Add(await GetCommodity(id));
            }

            return commodities;
        }

        public async Task<CommodityValue> GetCommodityValue(string id)
        {
            var path = $@"{DbRootPath}/{id}/value.json";
            using StreamReader file = new(path);
            var json = await file.ReadToEndAsync();
            var commodityValue = JsonSerializer.Deserialize<CommodityValue>(json)
                                 ?? throw new Exception($"{path} json value deserialize Commodity Fail.");
            commodityValue.Id = id;
            return commodityValue;
        }

        private async Task<Commodity> GetCommodity(string id) =>
            new(await GetCommodityValue(id))
            {
                Images = new List<string>()
                {
                    await GetImage(id, new DirectoryInfo($@"{DbRootPath}/{id}/img")
                        .GetFiles("*.jpg")
                        .Select(fi => fi.Name)
                        .FirstOrDefault())
                }
            };

        private async Task<string> GetImage(string id, string imgName)
        {
            var image =
                await File.ReadAllBytesAsync($@"{DbRootPath}/{id}/img/{imgName}");
            return Convert.ToBase64String(image);
        }

        private async Task<List<string>> GetAllImages(string id, List<string> imgNames)
        {
            var images = new List<string>();
            foreach (var imgName in imgNames)
            {
                var image =
                    await File.ReadAllBytesAsync($@"{DbRootPath}/{id}/img/{imgName}");
                images.Add(Convert.ToBase64String(image));
            }

            return images;
        }
    }
}
