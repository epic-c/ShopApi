using System;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ShopApi.Helper
{
    public class BasicAuth
    {
        public (string userId, string password) Parse(HttpRequest request)
        {
            var basicAuthOfHeader = request?.Headers["Authorization"] ?? "Basic VGVzdElkOnRlc3Q=";

            if (string.IsNullOrEmpty(basicAuthOfHeader))
            {
                return (string.Empty, string.Empty);
            }

            basicAuthOfHeader = basicAuthOfHeader.ToString()[6..]; // format: "Basic WiJFjjadfji" , remove "Basic "
            var authDecode = Encoding.UTF8.GetString(Convert.FromBase64String(basicAuthOfHeader));
            var userIdAndPwd = authDecode.Split(":");

            return (userIdAndPwd[0], userIdAndPwd[1]);
        }
    }
}
