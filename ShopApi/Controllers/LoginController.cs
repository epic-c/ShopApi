using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Login()
        {
            try
            {
                return Ok("token");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
}
}
