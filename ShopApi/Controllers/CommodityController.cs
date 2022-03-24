using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Helper;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetCommodities()
        {
            try
            {
                var commodities = await Repository.GetCommodities();
                return Ok(commodities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       

        [HttpGet("{name}")]
        public async Task<ActionResult<Commodity>> GetCommodity(string name)
        {
            try
            {
                var commodity = await Repository.GetCommodity(name);
                return Ok(commodity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
