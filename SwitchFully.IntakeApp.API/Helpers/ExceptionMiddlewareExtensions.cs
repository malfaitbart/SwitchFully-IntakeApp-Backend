using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SwitchFully.IntakeApp.Domain.ErrorHandling;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Net;

namespace SwitchFully.IntakeApp.API.Helpers
{
	public static class ExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					//context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						Guid guid = Guid.NewGuid();
						string errormessage = $"Error ID: {guid} => {contextFeature.Error.Message}";
						logger.LogError(errormessage);

						await context.Response.WriteAsync(new ErrorDetails()
						{
							StatusCode = context.Response.StatusCode,
							Message = errormessage
						}.ToString());
					}
				});
			});
		}
	}
}
