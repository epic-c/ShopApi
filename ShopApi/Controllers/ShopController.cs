using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetCommoditys()
        {
            try
            {
                var imageArray = await System.IO.File.ReadAllBytesAsync(@"./DB/1.jpg");
                var base64ImageRepresentation = Convert.ToBase64String(imageArray);

                return Ok(new List<Commodity>()
                {
                    new()
                    {
                        Images = new []{base64ImageRepresentation},
                        Comment = "",
                        Name = "",
                        Price = 0.0
                    }
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Name}")]
        public async Task<ActionResult<Commodity>> GetCommodity(string Name)
        {
            try
            {
                var imageArray = await System.IO.File.ReadAllBytesAsync(@"./DB/1.jpg");
                var base64ImageRepresentation = Convert.ToBase64String(imageArray);

                return Ok(new Commodity()
                    {
                        Images = new []{base64ImageRepresentation},
                        Comment = "",
                        Name = "",
                        Price = 0.0
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
