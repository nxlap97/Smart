using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Smart.Core.Domain;
using Smart.Data;
using Smart.Data.Infrastructor;
using Smart.Service.EF.Products;
using Smart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Smart.Website.Infrastructor.Schedules
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private TelemetryClient _telemetryClient;
        private static HttpClient _httpClient = new HttpClient();
        private  IProductService _productService;
        private SmartDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public IConfiguration Configuration { get; }
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            Configuration = configuration;
            //_productService = productService;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // var scope = _serviceProvider.CreateScope();
                //var context = scope.ServiceProvider.GetRequiredService<DbContext>();
                //IServiceCollection services = new ServiceCollection();
                //IServiceProvider serviceProvider = services.BuildServiceProvider();
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //var result = _productService.GetAll();
                //var result = context.Set<Product>().FirstOrDefault();
                //using (_telemetryClient.StartOperation<RequestTelemetry>("operation"))
                //{
                //    _logger.LogWarning("A sample warning message. By default, logs with severity Warning or higher is captured by Application Insights");
                //    _logger.LogInformation("Calling bing.com");
                //    var res = await _httpClient.GetAsync("https://bing.com");
                //    _logger.LogInformation("Calling bing completed with status:" + res.StatusCode);
                //    _telemetryClient.TrackEvent("Bing call event completed");
                //}

                using (var scope = _serviceProvider.CreateScope())
                {
                   // IServiceCollection services = new ServiceCollection();
                    //IServiceProvider serviceProvider = services.BuildServiceProvider();
                    //var dbcontxt = services.AddDbContext<SmartDbContext>(options =>
                    //                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    //                o => o.MigrationsAssembly("Smart.Data")));
                    var result = scope.ServiceProvider.GetRequiredService<IProductService>();
                    var products = result.GetAll();
                   // result.Products.GetAll().ToList();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        public void test([FromServices] IProductService productService)
        {

        }
    }
}
