using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ShopApi.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> PostBill()
        {
            try
            {
                return Ok("bill");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
