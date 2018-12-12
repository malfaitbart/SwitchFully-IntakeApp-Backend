using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using SwitchFully.IntakeApp.API;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.API.Users.Mapper;
using SwitchFully.IntakeApp.Data;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Data.Repositories.Users;
using SwitchFully.IntakeApp.Service.Campaigns;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;
using SwitchFully.IntakeApp.Service.Security;
using SwitchFully.IntakeApp.Service.Users;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "SwitchFully Intake App",
                    Version = "v1"
                });
            });

            services.AddScoped<ILoggerManager, LoggerManager>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();

            services.AddScoped<CampaignRepository>();
            services.AddScoped<CandidateRepository>();
            services.AddScoped<JobApplicationRepository>();

            services.AddScoped<UserMapper>();
            services.AddScoped<ICandidateMapper, CandidateMapper>();
            services.AddSingleton<ICampaignMapper, CampaignMapper>();
            services.AddScoped<JobApplicationMapper>();
            services.AddScoped<StatusMapper>();

            services.AddScoped<Hasher>();
            services.AddScoped<Salter>();
            services.AddScoped<UserAuthenticationService>();

            services.AddTransient<SwitchFullyIntakeAppContext>();


            services.AddDbContext<SwitchFullyIntakeAppContext>(options =>
                    options.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=SwitchfullyIntakeApp;Integrated Security=True;")
                );
            services.AddDbContext<SwitchFullyIntakeAppContext>(DbContext =>
                    DbContext.UseInMemoryDatabase("SwitchDb" + Guid.NewGuid().ToString("N"))
                );




            services.AddScoped<UserRepository>();
        }







        protected override void ConfigureAdditionalMiddleware(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<TestMiddleware.AuthenticatedTestRequestMiddleware>();
        }
    }
}
