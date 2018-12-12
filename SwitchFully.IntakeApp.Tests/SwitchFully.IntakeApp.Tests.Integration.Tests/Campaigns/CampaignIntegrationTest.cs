using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestMiddleware;
using Xunit;

namespace SwitchFully.IntakeApp.Integration.Tests.Campaigns
{

    public class CampaignIntegrationTest 
    {
        private readonly HttpClient _client;

        private CampaignDTO_Create campaignToCreate = new CampaignDTO_Create { Client = "vab1", Name = "java", EndDate = DateTime.Now.AddDays(3), StartDate = DateTime.Now.AddDays(7) };



        public CampaignIntegrationTest()
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

        private async Task<HttpResponseMessage> PostNewCampaign()
        {
            var content = JsonConvert.SerializeObject(campaignToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/campaigns", stringContent);
            response.EnsureSuccessStatusCode();
            return response;
        }

        private void AssertCampaignIsEqual(CampaignDTO_Create campaignToCreate, CampaignDTO_Return createdCampaign)
        {
            Assert.Equal(campaignToCreate.Name, createdCampaign.Name);
            Assert.Equal(campaignToCreate.Client, createdCampaign.Client);
            Assert.Equal(campaignToCreate.EndDate, createdCampaign.EndDate);
            Assert.Equal(campaignToCreate.StartDate, createdCampaign.StartDate);
        }



        [Fact]
        public async Task CreateNewCampaign()
        {
            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            HttpResponseMessage response = await PostNewCampaign();

            var responseString = await response.Content.ReadAsStringAsync();           
            var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            AssertCampaignIsEqual(campaignToCreate, createdCampaign);
            Assert.True(createdCampaign.CampaignId != Guid.Empty);
        }
        
        [Fact]
        public async Task GetAllCampaigns()
        {
            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);

            HttpResponseMessage responseCreate1 = await PostNewCampaign();
            HttpResponseMessage responseCreate2 = await PostNewCampaign();
            HttpResponseMessage responseCreate3 = await PostNewCampaign();


            var response = await _client.GetAsync("/api/campaigns");
            response.EnsureSuccessStatusCode();


            var responseString = await response.Content.ReadAsStringAsync();
            var allCampaigns = JsonConvert.DeserializeObject<IEnumerable<CampaignDTO_Return>>(responseString);

            Assert.NotEmpty(allCampaigns);
        }

        [Fact]
        public async Task GetSingleCampaign()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            HttpResponseMessage responseCreate = await PostNewCampaign();


            var responseString = await responseCreate.Content.ReadAsStringAsync();
            var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);            
            var responseReturn = await _client.GetAsync("/api/campaigns/id:string?id=" + createdCampaign.CampaignId.ToString());
            responseReturn.EnsureSuccessStatusCode();


            var responseStringReturn = await responseReturn.Content.ReadAsStringAsync();
            var singleCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            Assert.Equal(createdCampaign.CampaignId.ToString(), singleCampaign.CampaignId.ToString());
        }
        
    }
}
