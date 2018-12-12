using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.API.Users.Dto;
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

        private readonly HttpClient _client;
        private UserRegisterDto userToRegister = new UserRegisterDto("firstName", "lastName", "test@test.test", "test");


        public UserIntegrationTests()
        {
            _client = new TestServer(new WebHostBuilder()
                .UseStartup(typeof(TestServerStartup))

                .UseConfiguration(
                    new ConfigurationBuilder()
                        .AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly)
                        .Build()
                ))
                .CreateClient();

        }

        private async Task<HttpResponseMessage> AuthenticateUser()
        {
            var content = JsonConvert.SerializeObject(userToRegister);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Users/authenticate", stringContent);
            return response;
        }
        private async Task<HttpResponseMessage> RegisterNewUser()
        {
            var content = JsonConvert.SerializeObject(userToRegister);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Users", stringContent);

            return response;
        }

        [Fact]
        public async Task TestToRegisterANewUser()
        {
            HttpResponseMessage response = await RegisterNewUser();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<UserDto>(responseString);


            Assert.True(createdUser != null);
            Assert.Equal(userToRegister.FirstName, createdUser.FirstName);
            Assert.Equal(userToRegister.LastName, createdUser.LastName);
            Assert.Equal(userToRegister.Email, createdUser.Email);
        }
        [Fact]
        public async Task TestToAuthenticateAUser()
        {
            HttpResponseMessage responseCreate = await RegisterNewUser();

            HttpResponseMessage response = await AuthenticateUser();

            var responseString = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenDTO>(responseString);


            Assert.True(token.Token != null);

        }
      

    }
}
