using System.Collections.Generic;
using System.Threading.Tasks;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Repositories
{
    public interface IParticipantRepository:IBaseRepository<Participant>
    {
        Task<IEnumerable<Participant>> findByArtEventIdAsync(long artEventId);
        Task<IEnumerable<Participant>> findByHobystIdAsync(long  hobystId);
    }
}
