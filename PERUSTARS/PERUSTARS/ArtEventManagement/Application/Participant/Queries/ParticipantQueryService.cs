using System.Collections.Generic;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Services.Participant;

namespace PERUSTARS.ArtEventManagement.Application.Participant.Queries
{
    public class ParticipantQueryService: IParticipantQueryService
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantQueryService(IParticipantRepository participantRepository)
        {
            this._participantRepository = participantRepository;
        }

        public IEnumerable<Domain.Model.Aggregates.Participant> getParticipantByEventId(long id)
        {
            return _participantRepository.findByArtEventIdAsync(id).Result;
        }

        public IEnumerable<Domain.Model.Aggregates.Participant> getParticipantByHobbyistId(long id)
        {
            return _participantRepository.findByHobystIdAsync(id).Result;
        }

        public Domain.Model.Aggregates.Participant getParticipantById(long id)
        {
            return _participantRepository.FindByIdAsync(id).Result;
        }

        public IEnumerable<Domain.Model.Aggregates.Participant> GetParticipants()
        {
            return _participantRepository.ListAsync().Result;
        }
    }
}
