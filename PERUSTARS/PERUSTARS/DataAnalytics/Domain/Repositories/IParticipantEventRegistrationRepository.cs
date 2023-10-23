using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PERUSTARS.DataAnalytics.Domain.Repositories
{
    public interface IParticipantEventRegistrationRepository:  IBaseRepository<ParticipantEventRegistration>
    {
        public Task<IEnumerable<ParticipantEventRegistration>> GetAllNotCollectedParticipantEventRegistrationsAsync();
    }
}
