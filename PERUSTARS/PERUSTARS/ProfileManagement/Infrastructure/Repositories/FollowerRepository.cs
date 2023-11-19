using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Infrastructure.Repositories
{
    public class FollowerRepository : BaseRepository<Follower>, IFollowerRepository
    {
        public FollowerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Artist>> findFollowedArtistByHobbyistId(long hobbyistId)
        {
            return await _dbContext.Followers.Where(f=>f.HobbyistId== hobbyistId).Select(f=>f.Artist).ToListAsync();
        }

        public async Task<Follower> findFollowerByHobbyistId(long hobbyistId)
        {
            return await _dbContext.Followers.Where(f=>f.HobbyistId== hobbyistId).FirstAsync();
        }

        public async Task<IEnumerable<Follower>> GetFollowerByArtistIdAsync(long artistId)
        {
            return await _dbContext.Followers.Where(f => f.ArtistId == artistId).ToListAsync();
        }
    }
}