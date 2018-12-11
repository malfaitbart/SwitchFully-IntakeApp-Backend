using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Campaigns.Controllers;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Helpers;
using SwitchFully.IntakeApp.Data;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Service.Campaigns;
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
        CampaignDTO_Create campaignToCreate = new CampaignDTO_Create { Client = "vab", Name = "java", EndDate = new DateTime(2018, 05, 21), StartDate = new DateTime(2018, 10, 22) };

        [Fact]
        public async Task CreateNewCampaign()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
            using (this._scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var content = JsonConvert.SerializeObject(campaignToCreate);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("/api/campaigns", stringContent);


                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

                AssertCampaignIsEqual(campaignToCreate, createdCampaign);
                Assert.True(createdCampaign.CampaignId != Guid.Empty);

                this._scope.Dispose();
            }
        }

        [Fact]
        public async Task GetAllCampaigns()
        {

            _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);


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


            var response = await _client.GetAsync("/api/campaigns/id:string?id=72993d43-bd59-4aae-b827-16e0198ec43b");


            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var singleCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

            Assert.Equal("72993d43-bd59-4aae-b827-16e0198ec43b", singleCampaign.CampaignId.ToString());
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
