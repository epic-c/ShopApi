using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApi.Helper;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtHelpers _jwt;
        private readonly IBasicAuth _basicAuth;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IJwtHelpers jwt, IBasicAuth basicAuth, ILogger<LoginController> logger)
        {
            _jwt = jwt;
            _basicAuth = basicAuth;
            _logger = logger;
        }

        [HttpPost()]
        public ActionResult<LoginToken> SignIn(int expireMinutes = 24 * 60)
        {
            try
            {
                var userData = _basicAuth.Parse(Request);  //this.Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(userData.userId) && string.IsNullOrEmpty(userData.password))
                {
                    return BadRequest(new MessageTemplate() { BadRequestError = "Id or pwd not exist." });
                }

                if (!CheckDBResult(userData))
                {
                    return BadRequest(new MessageTemplate() { BadRequestError = "Id or pwd error." });
                }

                return Ok(new LoginToken() { Token = _jwt.GenerateToken(userData.userId, expireMinutes) });
            }
            catch (Exception e)
            {
                return BadRequest(new MessageTemplate { BadRequestError = e.Message });
            }
        }

        private bool CheckDBResult((string userId, string password) user)
        {
            return true;
        }
    }
}