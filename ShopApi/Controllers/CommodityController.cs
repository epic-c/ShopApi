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
        private readonly ICommodityRepository _iCommodityRepository;

        public CommodityController(ICommodityRepository iCommodityRepository)
        {
            _iCommodityRepository = iCommodityRepository;
        }
        [HttpGet("Commodities")]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetCommodities()
        {
            try
            {
                var commodities = await _iCommodityRepository.GetCommodities();
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
                var commodity = await _iCommodityRepository.GetCommodity(name);
                return Ok(commodity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
