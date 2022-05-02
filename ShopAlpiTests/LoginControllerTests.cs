using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ShopApi.Controllers;
using ShopApi.Helper;
using ShopApi.Models;

namespace ShopApiTests
{
    [TestFixture]
    internal class LoginControllerTests
    {
        private IJwtHelpers _jwt;
        private IBasicAuth _basicAuth;
        private LoginController _loginController;

        [SetUp]
        public void SetUp()
        {
            _jwt = NSubstitute.Substitute.For<IJwtHelpers>();
            _basicAuth = NSubstitute.Substitute.For<IBasicAuth>();
            _loginController = new LoginController(_jwt, _basicAuth, new NullLogger<LoginController>());
        }

        [Test]
        public void LoginControllerSignIn_WhenCorrectBasicAuth_ReturnCorrectToken()
        {
            const string userName = "test";
            const string token = "123";
            
            _basicAuth.Parse(Arg.Any<HttpRequest>()).Returns((userName, "132"));
            _jwt.GenerateToken(userName, 1440).Returns(token);
            var result = _loginController.SignIn();

            Assert.That(((ObjectResult)result.Result).StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            _basicAuth.Received(1).Parse(Arg.Any<HttpRequest>());
            Assert.That(((LoginToken)((ObjectResult)result.Result).Value).Token, Is.EqualTo(token));
        }

        [Test]
        public void LoginControllerSignIn_WhenCorrectBasicAuth_ReturnCorrectToken2()
        {
            _basicAuth.Parse(Arg.Any<HttpRequest>()).Throws<Exception>();
            var result = _loginController.SignIn();
            
            Assert.That(((ObjectResult)result.Result).StatusCode,Is.EqualTo(StatusCodes.Status400BadRequest));
            Assert.That(
                ((MessageTemplate)((ObjectResult)result.Result).Value).BadRequestError, 
                Is.EqualTo("Exception of type 'System.Exception' was thrown."));
        }

    }
}
