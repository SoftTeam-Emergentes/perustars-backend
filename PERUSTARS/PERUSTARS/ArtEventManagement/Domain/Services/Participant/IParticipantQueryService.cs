using System.Collections.Generic;

namespace PERUSTARS.ArtEventManagement.Domain.Services.Participant
{
    public interface IParticipantQueryService
    {
        public Model.Aggregates.Participant getParticipantById(long id);
        public IEnumerable<Model.Aggregates.Participant>  getParticipantByHobbyistId(long id);
        public IEnumerable<Model.Aggregates.Participant> getParticipantByEventId(long id);
        public IEnumerable<Model.Aggregates.Participant> GetParticipants();
    }
}
