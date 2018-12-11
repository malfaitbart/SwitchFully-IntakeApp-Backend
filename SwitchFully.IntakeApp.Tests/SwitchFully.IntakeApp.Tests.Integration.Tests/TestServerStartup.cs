using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SwitchFully.IntakeApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Integration.Tests
{

        public class TestServerStartup : Startup
        {
            public TestServerStartup(IConfiguration configuration) : base(configuration)
            {
            }

            protected override void ConfigureAdditionalMiddleware(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.UseMiddleware<TestMiddleware.AuthenticatedTestRequestMiddleware>();
            }
        }


}
