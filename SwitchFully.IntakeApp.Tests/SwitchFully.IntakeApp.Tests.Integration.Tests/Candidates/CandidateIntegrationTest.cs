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


namespace SwitchFully.IntakeApp.Integration.Tests.Candidates
{

    public class CandidateIntegrationTest
    {
        private readonly HttpClient _client;
        CandidateDtoWithoutId candidateToCreate = new CandidateDtoWithoutId { Email = "test@test.test", FirstName = "test", LastName = "test"};



        public CandidateIntegrationTest()
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

        private void AssertCampaignIsEqual(CandidateDto candidateToCompare, CandidateDtoWithoutId candidateReference)
        {
            Assert.Equal(candidateToCompare.Email, candidateReference.Email);
            Assert.Equal(candidateToCompare.LastName, candidateReference.LastName);
            Assert.Equal(candidateToCompare.FirstName, candidateReference.FirstName);
        }

        private async Task<HttpResponseMessage> PostNewCandidate()
        {
            var content = JsonConvert.SerializeObject(candidateToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/candidates", stringContent);
            response.EnsureSuccessStatusCode();
            return response;
        }



        [Fact]
        public async Task CreateNewCandidate()
        {
            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            HttpResponseMessage response = await PostNewCandidate();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseString);

            AssertCampaignIsEqual(createdCandidate, candidateToCreate);
            Assert.True(createdCandidate.Id != null);
        }

        [Fact]
        public async Task GetAllCandidate()
        {
            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);

            HttpResponseMessage responseCreate1 = await PostNewCandidate();
            HttpResponseMessage responseCreate2 = await PostNewCandidate();
            HttpResponseMessage responseCreate3 = await PostNewCandidate();


            var response = await _client.GetAsync("/api/candidates");
            response.EnsureSuccessStatusCode();


            var responseString = await response.Content.ReadAsStringAsync();
            var allCampaigns = JsonConvert.DeserializeObject<IEnumerable<CandidateDto>>(responseString);

            Assert.NotEmpty(allCampaigns);
        }

        [Fact]
        public async Task GetSingleCandidate()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            HttpResponseMessage responseCreate = await PostNewCandidate();


            var responseString = await responseCreate.Content.ReadAsStringAsync();
            var createdCandidate = JsonConvert.DeserializeObject<CandidateDto>(responseString);
            var responseReturn = await _client.GetAsync("/api/candidates/" + createdCandidate.Id.ToString());
            responseReturn.EnsureSuccessStatusCode();


            var responseStringReturn = await responseReturn.Content.ReadAsStringAsync();
            var singlecandidate = JsonConvert.DeserializeObject<CandidateDto>(responseString);

            Assert.Equal(createdCandidate.Id.ToString(), singlecandidate.Id.ToString());
        }


    }
}