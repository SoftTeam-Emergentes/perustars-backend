using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, IEnumerable<ParticipantEventRegistration>>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IParticipantEventRegistrationRepository _participantEventRegistrationRepository;

        public CollectEventLogDataCommandHandler(IPublisher publisher, IMapper mapper, IParticipantEventRegistrationRepository participantEventRegistrationRepository)
        {
            _publisher = publisher;
            _mapper = mapper;
            _participantEventRegistrationRepository = participantEventRegistrationRepository;
        }

        public async Task<IEnumerable<ParticipantEventRegistration>> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            return await _participantEventRegistrationRepository.GetAllNotCollectedParticipantEventRegistrationsAsync();
        }
    }
}
