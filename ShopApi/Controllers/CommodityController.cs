using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShopApi.Models;
using ShopApi.Repository;

namespace ShopApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        private ICommodityRepository _commodityRepository;

        public CommodityController(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }

        [HttpGet("Commodities")]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetCommodities()
        {
            try
            {
                var commodities = await _commodityRepository.GetCommodities();
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
                var commodity = await _commodityRepository.GetCommodity(name);
                return Ok(commodity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
