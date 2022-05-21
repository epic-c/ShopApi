using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ShopApi.Helper;
using ShopApi.Models;
using ShopApi.Models.Payment;
using ShopApi.Repository.CommodityRepository;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MemberController : ControllerBase
    {
        private readonly IPayee _payee;
        private readonly ILogger<MemberController> _logger;
        private readonly ICommodityRepository _commodityRepository;

        public MemberController(
            ILogger<MemberController> logger,
            IPayee payee,
            ICommodityRepository commodityRepository)
        {
            _payee = payee;
            _logger = logger;
            _commodityRepository = commodityRepository;
        }

        [HttpPost("Payment")]
        public async Task<ActionResult<Remittance>> BillingPayment(Orders orders)
        {
            try
            {
                var consumerDetails = new List<ConsumerDetail>();
                foreach (var order in orders.Value)
                {
                    var commodityValue = await _commodityRepository.GetCommodityValue(order.Id);
                    consumerDetails.Add(new ConsumerDetail
                    {
                        Name = commodityValue.Name,
                        Price = commodityValue.Price,
                        Amount = order.Amount
                    });
                }
                return Ok(new Remittance 
                {
                    ConsumerDetails = consumerDetails,
                    Account = await _payee.GetRemittanceAccount(),
                    Deadline = DateTime.Now.AddDays(3)
                });
            }
            catch (Exception e)
            {
                return BadRequest(new MessageTemplate { BadRequestError = e.Message });
            }
        }
    }
}
