using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.DataAnalytics.Domain.Services;
using PERUSTARS.DataAnalytics.Domain.Model.Aggregates;
using PERUSTARS.DataAnalytics.Domain.Model.Events;
using AutoMapper;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, bool>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public CollectEventLogDataCommandHandler(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            // TODO: Implement mapping profiles to map this command to its respective domain event
            EventLogDataCollectedEvent domainEvent = _mapper.Map<EventLogDataCollectedEvent>(request);
            await _publisher.Publish(domainEvent, cancellationToken);
            return await Task.FromResult(true);
        }
    }
}
