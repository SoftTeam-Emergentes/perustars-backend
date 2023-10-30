using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, IEnumerable<ParticipantEventRegistration>>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public CollectEventLogDataCommandHandler(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantEventRegistration>> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<ParticipantEventRegistration>());
        }
    }
}
