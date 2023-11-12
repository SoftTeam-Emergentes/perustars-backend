using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Domain.Repositories
{
    public interface IFollowerRepository: IBaseRepository<Follower>
    {
        Task<IEnumerable<Follower>> GetFollowerByArtistIdAsync(long artistId);
    }
}