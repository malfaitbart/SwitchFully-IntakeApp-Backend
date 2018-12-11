using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestMiddleware
{
    public class AuthenticatedTestRequestMiddleware
    {
        public const string FakeJWTAuthentication = "FakeAuthentication";
        public const string TestingHeader = "Authorization";
        public const string TestingHeaderValue = "X-Integration-Test";

        private readonly RequestDelegate _next;

        public AuthenticatedTestRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
             if (context.Request.Headers.Keys.Contains(TestingHeader) 
                && context.Request.Headers[TestingHeader].First().Equals(TestingHeaderValue))
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>
                    {
                         new Claim(ClaimTypes.Email, "test@gmail.com")
                    }, FakeJWTAuthentication);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    context.User = claimsPrincipal;
            }

            await _next(context);
        }
    }
}