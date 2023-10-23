using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Infrastructure.Repositories
{
    public class ArtistArtworkRecommendationRepository : BaseRepository<ArtistArtworkRecommendation>, IArtistArtworkRecommendationRepository
    {
        public ArtistArtworkRecommendationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ArtistArtworkRecommendation>> GetAllNotCollectedArtistRecommendationsAsync()
        {
            return await _dbContext.ArtistRecommendations
                .Where(ar => ar.Collected == false)
                .ToListAsync();
        }
    }
}
