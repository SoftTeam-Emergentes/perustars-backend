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
    public class ArtistArtworkRecommendationRepository : BaseRepository<ArtistRecommendation>, IArtistArtworkRecommendationRepository
    {
        public ArtistArtworkRecommendationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ArtistRecommendation>> GetAllNotCollectedArtistRecommendationsAsync()
        {
            return await _dbContext.ArtistRecommendations
                .Where(ar => ar.Collected == false)
                .ToListAsync();
        }
    }
}
