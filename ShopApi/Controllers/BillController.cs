using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ShopApi.Repository;
using System.Collections.Generic;
using ShopApi.Models.Bill;

namespace ShopApi.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        [HttpGet("AllBill")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBill()
        {
            try
            {
                var result = await _billRepository.GetBills();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
