using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using My.SO.SampleWebApi.Infrastructure;
using System;
using System.IO;

namespace My.SO.SampleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                var host = CreateHostBuilder(args).Build();

                CreateDbIfNotExists(host);
                host.Run();
            }
            catch
            {
            }
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<SchoolDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseIISIntegration()
                    .UseStartup<Startup>();
                });
    }
}
