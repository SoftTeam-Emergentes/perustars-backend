using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Aggregates;
using PERUSTARS.DataAnalytics.Domain.Model.Events;
using PERUSTARS.DataAnalytics.Domain.Services;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.EventServices
{
    public class EventLogDataCollectedEventHandler : INotificationHandler<EventLogDataCollectedEvent>
    {
        private IMapper _mapper;
        public EventLogDataCollectedEventHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Handle(EventLogDataCollectedEvent notification, CancellationToken cancellationToken)
        {
            ConcurrentQueue<DataAnalytic> data = DataAnalyticsFormatter.pendingToCompleteDataAnalyticsElements;
            DataAnalytic newDataAnalytic = _mapper.Map<DataAnalytic>(notification);
            data.Enqueue(newDataAnalytic);
        }
    }
}
