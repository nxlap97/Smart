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
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<DesignTimeDbContextFactory>(new DesignTimeDbContextFactory()); /*- Giúp lấy dữ liệu từ dbContext*/
                 services.AddHostedService<Worker>();  /* Khởi tạo và chạy vào luôn */
                 services.AddApplicationInsightsTelemetryWorkerService();
             });
               
                
    }
    
}
