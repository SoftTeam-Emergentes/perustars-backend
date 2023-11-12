using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Jobs
{
    public class DataAnalyticsJob : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        private readonly PeruStarsMLServiceFeignClient _peruStarsMLServiceFeignClient;
        private readonly ILogger<DataAnalyticsJob> _logger;

        public DataAnalyticsJob(IServiceProvider serviceProvider, PeruStarsMLServiceFeignClient peruStarsMLServiceFeignClient)
        {
            _serviceProvider = serviceProvider;
            _peruStarsMLServiceFeignClient = peruStarsMLServiceFeignClient;
            using var scope = _serviceProvider.CreateScope();
            _logger = scope.ServiceProvider.GetRequiredService<ILogger<DataAnalyticsJob>>();
        }

        private async void ComputeRecommendationData(object state)
        {
            bool isSuccess = await _peruStarsMLServiceFeignClient.ComputeRecommendationSystem();
            if (isSuccess) _logger.LogInformation("Remote call to perustars-ml-api was successfully executed");
            else _logger.LogError("Remote call to perustars-ml-api failed");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting Data Analytics Scheduled Job");
            _timer = new Timer(ComputeRecommendationData, null, TimeSpan.Zero, TimeSpan.FromHours(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Data Analytics Scheduled Job");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose() => _timer.Dispose();
    }
}
