using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.Data;
using System;

namespace SwitchFully.IntakeApp.Integration.Tests
{

    public class TestServerStartup : Startup
    {
        public TestServerStartup(IConfiguration configuration) : base(configuration)
        {
        }


        public override void ConfigureServices(IServiceCollection services)
        {
            ConfigureAdditionalServices(services);
        }

        protected override void ConfigureAdditionalServices(IServiceCollection services)
        {
            services.AddDbContext<SwitchFullyIntakeAppContext>(DbContext =>
                    DbContext.UseInMemoryDatabase("SwitchDb" + Guid.NewGuid().ToString("N")),
                    ServiceLifetime.Singleton

                );

            base.ConfigureAdditionalServices(services);
        }


        protected override void ConfigureAdditionalMiddleware(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<TestMiddleware.AuthenticatedTestRequestMiddleware>();
        }
    }
}
