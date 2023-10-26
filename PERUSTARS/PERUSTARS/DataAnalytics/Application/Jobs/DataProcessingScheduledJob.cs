using Microsoft.Extensions.Hosting;
using PERUSTARS.DataAnalytics.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Jobs
{
    public class DataProcessingScheduledJob : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IDataAnalyticsCommandService _dataAnalyticsCommandService;

        public DataProcessingScheduledJob(IDataAnalyticsCommandService dataAnalyticsCommandService)
        {
            _dataAnalyticsCommandService = dataAnalyticsCommandService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(ProcessDataAndSendToML, null, TimeSpan.Zero, TimeSpan.FromHours(5));
            return Task.CompletedTask;
        }

        public async void ProcessDataAndSendToML(object state)
        {
            await _dataAnalyticsCommandService.SaveTrainingDataToDb();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose() => _timer?.Dispose();
    }
}
