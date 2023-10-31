using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.ArtworkManagement.Infrastructure.Repositories
{
    public class ArtworkRecommendationRepository : BaseRepository<ArtworkRecommendation>, IArtworkRecommendationRepository
    {
        public ArtworkRecommendationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
