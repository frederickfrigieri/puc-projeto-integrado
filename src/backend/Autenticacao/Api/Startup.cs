using Api.Configuration;
using Application;
using Domain._Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
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

            //var esConfig = _configuration.GetSection("Serilog:Elasticsearch").Get<SerilogElasticsearchConfig>();

            //Log.Logger = new LoggerConfiguration()
            //    .CreateDefaultInstance("EzCore.Usuario")
            //    .WithES(esConfig).CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionstring = _configuration.GetConnectionString("ConnectionString");
            var jwtSecret = _configuration.GetSection("JWTSecretToken").Value;

            services.RegisterFilterException();
            services.RegisterLogRequestResponseService();
            services.AddControllers();
            services.RegisterAuthtentication(jwtSecret);
            services.AddMemoryCache();
            services.AddSwaggerDocumentation();

            services.AddScoped<IRepository, RepositoryImplementation>();
            services.AddDbContext<RepositoryDbContext>(opt =>
            {
                opt.UseSqlServer(connectionstring, x => x.MigrationsHistoryTable("MigrationsHistory", "Identidade"));
            });

            services.AddScoped<IAutenticacao, AutenticacaoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IIdentidade, IdentidadeService>();
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
