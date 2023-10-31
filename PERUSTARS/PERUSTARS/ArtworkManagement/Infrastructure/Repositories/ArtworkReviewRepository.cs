using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.ArtworkManagement.Infrastructure.Repositories
{
    public class ArtworkReviewRepository : BaseRepository<ArtworkReview>, IArtworkReviewRepository
    {
        public ArtworkReviewRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<ArtworkReview> FindArtworkReviewByHobbyistIdAndArtworkIdAsync(long hobbyistId, long artworkId)
        {
            return await _dbContext.ArtworkReviews.FirstOrDefaultAsync(review => review.HobbyistId == hobbyistId && review.ArtworkId == artworkId);
        }
    }
}
