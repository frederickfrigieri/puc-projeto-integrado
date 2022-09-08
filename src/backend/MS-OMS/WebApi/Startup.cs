using System;
using Api._Configuration;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.RequestResponse.Extensions;
using Serilog.RequestResponse.Extensions.Models;
using Serilog.RequestResponseExtension.Extensions;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            ApplicationStartup.ConfigureLogger(_configuration);
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterFilterException();
            services.RegisterLogRequestResponseService();
            services.AddControllers();
            services.AddMemoryCache();
            services.AddSwaggerDocumentation();
            services.AddHttpContextAccessor();
            services.AddJWT(_configuration);

            return ApplicationStartup.Initialize(services, _configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.RegisterLogRequestResponseMiddleware(new SerilogOptions { UseFilterException = true });

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseRouting();
            app.UseCors(options =>
            {
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
