using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Smart.Service.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smart.Website.Infrastructor.Schedules
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var result = scope.ServiceProvider.GetRequiredService<IProductService>();
                    var products = result.GetAll();
                }
                await Task.Delay(int.MaxValue, stoppingToken);
            }
        }
    }
}
