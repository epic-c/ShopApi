using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using NUnit.Framework;
using ShopApi.Helper;

namespace ShopApiTests
{
    [TestFixture]
    public class BasicAuthTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicAuthParse_WhenCorrectAuthorization_ReturnsCorrectUserIdAndPwd()
        {
            var httpRequest = NSubstitute.Substitute.For<HttpRequest>();
            httpRequest.Headers["Authorization"].Returns(new StringValues("Basic VGVzdElkOnRlc3Q="));

            var basicAuth = new ShopApi.Helper.BasicAuth();
            var (userId, password) = basicAuth.Parse(httpRequest);

            Assert.That(userId, Is.EqualTo("TestId"));
            Assert.That(password, Is.EqualTo("test"));
        }

        [Test]
        public void BasicAuthParse_WhenEmptyAuthorization_ReturnsEmptyUserIdAndPwd()
        {
            var httpRequest = NSubstitute.Substitute.For<HttpRequest>();
            httpRequest.Headers["Authorization"].Returns(new StringValues(""));

            var basicAuth = new ShopApi.Helper.BasicAuth();
            var (userId, password) = basicAuth.Parse(httpRequest);

            Assert.That(userId, Is.EqualTo(string.Empty));
            Assert.That(password, Is.EqualTo(string.Empty));
        }

     
    }
}