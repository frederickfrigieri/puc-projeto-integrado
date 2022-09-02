using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace HangfireJobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
#endif

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
