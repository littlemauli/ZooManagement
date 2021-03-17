using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using ZooManagement.Data;
using NLog.Web;


namespace ZooManagement
{
    public class Program
    {
        // private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            // var config = new LoggingConfiguration();
            // var target = new FileTarget { FileName = @"C:\Work\Logs\ZooManagement.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            // config.AddTarget("File Logger", target);
            // // config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            // config.LoggingRules.Add(new LoggingRule("*", target));
            // LogManager.Configuration = config;
            // Logger.Info("The program has started");

            // CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }
        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooManagementDbContext>();
            context.Database.EnsureCreated();

            if (!context.AnimalType.Any())
            {
                var animalType = SampleAnimalType.GetAnimalTypes();
                context.AnimalType.AddRange(animalType);
                context.SaveChanges();

                var animals = SampleAnimal.GetAnimal();
                context.Animal.AddRange(animals);
                context.SaveChanges();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
                // .ConfigureLogging(logging =>
                // {
                //     logging.ClearProviders();
                //     logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                // })
                // .UseNLog();  // NLog: Setup NLog for Dependency injection
    }
}

