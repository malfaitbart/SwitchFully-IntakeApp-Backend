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
using System.Transactions;
using TestMiddleware;
using Xunit;

namespace SwitchFully.IntakeApp.Integration.Tests.Campaigns
{

    public class CampaignIntegrationTest : IDisposable
    {
        private readonly HttpClient _client;
        private TransactionScope _scope;
        CampaignDTO_Create campaignToCreate;
        CampaignDTO_Return campaignToReturn;
        Guid defaultGuid;



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

            campaignToCreate = new CampaignDTO_Create { Client = "vab", Name = "java", EndDate = DateTime.Now.AddDays(3), StartDate = DateTime.Now.AddDays(7) };
            defaultGuid = Guid.NewGuid();
            campaignToReturn = new CampaignDTO_Return { CampaignId = defaultGuid, Client = "random", Name = "Modnar", EndDate = DateTime.Now.AddDays(3), StartDate = DateTime.Now.AddDays(7) };
        }
        [Fact]
        public async Task CreateNewCampaign()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);

            var content = JsonConvert.SerializeObject(campaignToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/campaigns", stringContent);


            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            AssertCampaignIsEqual(campaignToCreate, createdCampaign);
            Assert.True(createdCampaign.CampaignId != Guid.Empty);

        }

        [Fact]
        public async Task GetAllCampaigns()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);

            var content1 = JsonConvert.SerializeObject(campaignToCreate);
            var stringContent1 = new StringContent(content1, Encoding.UTF8, "application/json");

            var response1 = await _client.PostAsync("/api/campaigns", stringContent1);
            response1.EnsureSuccessStatusCode();
            var content2 = JsonConvert.SerializeObject(campaignToCreate);
            var stringContent2 = new StringContent(content2, Encoding.UTF8, "application/json");

            var response2 = await _client.PostAsync("/api/campaigns", stringContent2);
            response2.EnsureSuccessStatusCode();






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
          
            var content = JsonConvert.SerializeObject(campaignToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var responseCreate = await _client.PostAsync("/api/campaigns", stringContent);


            responseCreate.EnsureSuccessStatusCode();

            var responseString = await responseCreate.Content.ReadAsStringAsync();
            var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            AssertCampaignIsEqual(campaignToCreate, createdCampaign);           



            var responseReturn = await _client.GetAsync("/api/campaigns/id:string?id=" + createdCampaign.CampaignId);

            responseReturn.EnsureSuccessStatusCode();

            var responseStringReturn = await responseReturn.Content.ReadAsStringAsync();
            var singleCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            Assert.Equal(createdCampaign.CampaignId.ToString(), singleCampaign.CampaignId.ToString());
        }

        private void AssertCampaignIsEqual(CampaignDTO_Create campaignToCreate, CampaignDTO_Return createdCampaign)
        {
            Assert.Equal(campaignToCreate.Name, createdCampaign.Name);
            Assert.Equal(campaignToCreate.Client, createdCampaign.Client);
            Assert.Equal(campaignToCreate.EndDate, createdCampaign.EndDate);
            Assert.Equal(campaignToCreate.StartDate, createdCampaign.StartDate);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
