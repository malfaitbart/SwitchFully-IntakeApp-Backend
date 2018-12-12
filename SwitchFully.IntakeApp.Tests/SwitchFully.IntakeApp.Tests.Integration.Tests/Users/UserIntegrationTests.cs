using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestMiddleware;
using Xunit;


namespace SwitchFully.IntakeApp.Integration.Tests.Users
{
    public class UserIntegrationTests
    {

        private readonly HttpClient _clien_AUTH;

        public UserIntegrationTests()
        {
            _clien_AUTH = new TestServer(new WebHostBuilder()
                .UseStartup(typeof(TestServerStartup))

                .UseConfiguration(
                    new ConfigurationBuilder()
                        .AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly)
                        .Build()
                ))
                .CreateClient();
        }

        [Fact]
        public async Task RegisterNewUser()
        {


        }
    }
}
