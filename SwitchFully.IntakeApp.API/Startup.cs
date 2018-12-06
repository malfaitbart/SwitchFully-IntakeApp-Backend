using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using SwitchFully.IntakeApp.Data;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.IO;

namespace SwitchFully.IntakeApp.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
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

			services.AddSingleton<ILoggerManager, LoggerManager>();
			services.AddTransient<SwitchFullyIntakeAppContext>();
			services.AddDbContext<SwitchFullyIntakeAppContext>(options =>
				options.UseSqlServer("Data Source=.\\SQLExpress;Initial Catalog=SwitchfullyIntakeApp;Integrated Security=True;")
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwitchFully Intake App V1");
				c.RoutePrefix = string.Empty;
			});
			app.UseMvc();
		}
	}
}
