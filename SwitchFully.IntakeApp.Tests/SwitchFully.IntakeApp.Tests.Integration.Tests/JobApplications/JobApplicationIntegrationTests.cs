using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestMiddleware;
using Xunit;

namespace SwitchFully.IntakeApp.Integration.Tests.JobApplications
{
    public class JobApplicationIntegrationTests
    {

        private readonly HttpClient _client;

        private JobApplicationDto_Create jobApplicationToCreate = new JobApplicationDto_Create() { CampaignId = Guid.NewGuid(), CandidateId = Guid.NewGuid() };

        public JobApplicationIntegrationTests()
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


        private async Task<HttpResponseMessage> PostNewJobApplication()
        {
            var content = JsonConvert.SerializeObject(jobApplicationToCreate);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/JobApplications", stringContent);
            response.EnsureSuccessStatusCode();
            return response;
        }

        private void AssertCampaignIsEqual(JobApplicationDto_Create applicationToCreate, JobApplicationDto createdApplication)
        {
            Assert.Equal(applicationToCreate.CampaignId.ToString(), createdApplication.Campaign.CampaignId.ToString());
            Assert.Equal(applicationToCreate.CandidateId.ToString(), createdApplication.Candidate.Id);
        }



        //[Fact]
        //public async Task CreateNewApplication()
        //{
        //    _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
        //    HttpResponseMessage response = await PostNewJobApplication();

        //    var responseString = await response.Content.ReadAsStringAsync();
        //    var createdApplication = JsonConvert.DeserializeObject<JobApplicationDto>(responseString);

        //    AssertCampaignIsEqual(jobApplicationToCreate, createdApplication);
        //}

        //[Fact]
        //public async Task GetAllCampaigns()
        //{
        //    _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);

        //    HttpResponseMessage responseCreate1 = await PostNewCampaign();
        //    HttpResponseMessage responseCreate2 = await PostNewCampaign();
        //    HttpResponseMessage responseCreate3 = await PostNewCampaign();


        //    var response = await _client.GetAsync("/api/campaigns");
        //    response.EnsureSuccessStatusCode();


        //    var responseString = await response.Content.ReadAsStringAsync();
        //    var allCampaigns = JsonConvert.DeserializeObject<IEnumerable<CampaignDTO_Return>>(responseString);

        //    Assert.NotEmpty(allCampaigns);
        //}

        //[Fact]
        //public async Task GetSingleCampaign()
        //{

        //    _client.DefaultRequestHeaders.Add(AuthenticatedTestRequestMiddleware.TestingHeader, AuthenticatedTestRequestMiddleware.TestingHeaderValue);
        //    HttpResponseMessage responseCreate = await PostNewCampaign();


        //    var responseString = await responseCreate.Content.ReadAsStringAsync();
        //    var createdCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);
        //    var responseReturn = await _client.GetAsync("/api/campaigns/id:string?id=" + createdCampaign.CampaignId.ToString());
        //    responseReturn.EnsureSuccessStatusCode();


        //    var responseStringReturn = await responseReturn.Content.ReadAsStringAsync();
        //    var singleCampaign = JsonConvert.DeserializeObject<CampaignDTO_Return>(responseString);

        //    Assert.Equal(createdCampaign.CampaignId.ToString(), singleCampaign.CampaignId.ToString());
        //}
    }
}
