using System.Collections;
using System.Collections.Generic;

namespace PERUSTARS.AtEventManagement.Domain.Services.Participant
{
    public interface IParticipantQueryService
    {
        public PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant getParticipantById(long id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant>  getParticipantByHobbyistId(long id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant> getParticipantByEventId(long id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant> GetParticipants();
    }
}
