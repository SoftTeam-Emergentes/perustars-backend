using MediatR;
using PERUSTARS.DataAnalytics.Domain.Services;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Services
{
    public class DataAnalyticsCommandService : IDataAnalyticsCommandService
    {
        private IMediator _mediator;
        public DataAnalyticsCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> ExecuteCollectEventLogDataCommandAsync(CollectEventLogDataCommand command)
        {
            await _mediator.Publish(command);
            return await Task.FromResult(true);
        }
    }
}
