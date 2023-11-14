using System.Collections.Generic;
using System.Threading.Tasks;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Repositories
{
    public interface IArtEventRepository:IBaseRepository<ArtEvent>
    {
        Task<IEnumerable<ArtEvent>> findByArtistIdAsync(long artistId);
        Task<IEnumerable<ArtEvent>> findByHobbyistIdAsync(long hobbyistId);
    }
}
