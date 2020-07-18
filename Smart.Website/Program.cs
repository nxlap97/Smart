using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Smart.Data;
using Smart.Website.Infrastructor.Schedules;

namespace Smart.Website
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //MainAsync(args);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static async Task MainAsync(string[] args)
        {
            //var host = new HostBuilder()
            // .ConfigureAppConfiguration((hostContext, config) =>
            // {
            //     config.AddJsonFile("appsettings.json", optional: true);
            // })
            // .ConfigureServices((hostContext, services) =>
            // {
            //     services.AddLogging();
            //     services.AddHostedService<TimedHostedService>();

            //    // instrumentation key is read automatically from appsettings.json
            //    services.AddApplicationInsightsTelemetryWorkerService();


            // })
            // .UseConsoleLifetime()
            // .Build();

            //using (host)
            //{
            //    new Thread(() =>
            //    {
            //        host.StartAsync();
            //        //host.WaitForShutdownAsync();
            //    });
            //}

            //CreateWebHostBuilder(args).Build().Run();

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<DesignTimeDbContextFactory>(new DesignTimeDbContextFactory());
                 services.AddHostedService<Worker>();
                 services.AddApplicationInsightsTelemetryWorkerService();
             });
               
                
    }
    
}
