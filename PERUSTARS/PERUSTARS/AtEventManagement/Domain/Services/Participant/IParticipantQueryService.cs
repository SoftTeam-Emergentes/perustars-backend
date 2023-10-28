using System.Collections;
using System.Collections.Generic;

namespace PERUSTARS.AtEventManagement.Domain.Services.Participant
{
    public interface IParticipantQueryService
    {
        public PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant getParticipantById(int id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant>  getParticipantByHobbyistId(int id);
        public void deleteParticipantById(int id);
        public IEnumerable<PERUSTARS.AtEventManagement.Domain.Model.Aggregates.Participant> getParticipantByEventId(int id);
    }
}
