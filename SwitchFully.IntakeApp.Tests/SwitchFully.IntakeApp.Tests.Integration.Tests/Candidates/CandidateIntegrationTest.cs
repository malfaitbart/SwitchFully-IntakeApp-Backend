using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using System;
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
        CandidateDto campaignToCreate =
            new CandidateDto {
                Email = "test@test.test",
                FirstName = "test",
                LastName = "test",
                Id = Guid.NewGuid().ToString()
            };


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
              

      
        

    }
}