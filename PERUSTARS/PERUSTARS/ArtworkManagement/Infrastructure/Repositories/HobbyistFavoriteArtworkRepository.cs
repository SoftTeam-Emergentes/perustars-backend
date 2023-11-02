using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PERUSTARS.ArtworkManagement.Infrastructure.Repositories
{
    public class HobbyistFavoriteArtworkRepository : BaseRepository<HobbyistFavoriteArtwork>, IHobbyistFavoriteArtworkRepository
    {
        public HobbyistFavoriteArtworkRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<HobbyistFavoriteArtwork> FindHobbyistFavoriteArtworkByHobbyistIdAndArtworkIdAsync(long hobbyistId, long artworkId)
        {
            return await _dbContext.HobbyistFavoriteArtworks.FirstOrDefaultAsync(hobbyistFavoriteArtwork => hobbyistFavoriteArtwork.HobbyistId == hobbyistId && hobbyistFavoriteArtwork.ArtworkId == artworkId);
        }
    }
}
