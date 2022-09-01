using Hangfire;
using HangfireBasicAuthenticationFilter;
using Infrastructure;
using Infrastructure.Processing.Outbox;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace HangfireJobs
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(_configuration.GetConnectionString("ConnectionString")));

            //Quando der erro vai tentar mais 3 vezes com intervalod de 3 minutos
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3, DelaysInSeconds = new int[] { 180 } });

            services.AddHangfireServer(x => x.WorkerCount = 1);

            services.AddControllers();

            //GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(container));

            return ApplicationStartup.Initialize(services, _configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DashboardOptions optionsHangFire = null;

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            optionsHangFire = new DashboardOptions
            {
                Authorization = new[] { new HangfireCustomBasicAuthenticationFilter { User = "hangfire", Pass = "123@Trocar" } }
            };

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseHangfireDashboard("", optionsHangFire);

            RecurringJob.RemoveIfExists(nameof(ProcessOutboxJob));
            RecurringJob.AddOrUpdate<ProcessOutboxJob>(nameof(ProcessOutboxJob),
                job => job.Run(JobCancellationToken.Null), "*/5 * * * * *", TimeZoneInfo.Local);
        }
    }
}
