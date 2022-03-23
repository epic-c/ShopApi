using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetCommodities()
        {
            try
            {
                var commodities = new List<Commodity>();

                var commoditiesName = new DirectoryInfo(@"./DB")
                    .GetDirectories("")
                    .Select(fi => fi.Name);

                foreach (var commodityName in commoditiesName)
                {
                    var commodity = await ShopController.GetCommodityItem(commodityName);

                    commodities.Add(commodity);
                }

                return Ok(commodities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private static async Task<Commodity> GetCommodityItem(string name)
        {
            var path = $@"./DB/{name}/value.json";
            using StreamReader r = new(path);
            var json = await r.ReadToEndAsync();
            var commodity = JsonSerializer.Deserialize<Commodity>(json)
                            ?? throw new Exception($"{path} json value deserialize Commodity Fail.");

            commodity.Images = new List<string>();
            var allImgNames = new DirectoryInfo($@"./DB/{name}/img")
                .GetFiles("*.jpg")
                .Select(fi => fi.Name)
                .ToList();

            foreach (var imgName in allImgNames)
            {
                var image =
                    await System.IO.File.ReadAllBytesAsync($@"./DB/{name}/img/{imgName}");
                commodity.Images.Add(Convert.ToBase64String(image));
            }

            return commodity;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Commodity>> GetCommodity(string name)
        {
            try
            {
                var commodity = await GetCommodityItem(name);
                return Ok(commodity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
