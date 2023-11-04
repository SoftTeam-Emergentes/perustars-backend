using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.ArtworkManagement.Infrastructure.Repositories
{
    public class ArtworkRecommendationRepository : BaseRepository<ArtworkRecommendation>, IArtworkRecommendationRepository
    {
        public ArtworkRecommendationRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<ArtworkRecommendation> FindArtworkRecommendationByHobbyistIdAndArtistIdAndArtworkIdAsync(long hobbyistId, long artistId, long artworkId)
        {
            return await _dbContext.ArtworkRecommendations.FirstOrDefaultAsync(artRec => artRec.HobbyistId == hobbyistId && artRec.ArtistId == artistId && artRec.ArtworkId == artworkId);
        }
    }
}
