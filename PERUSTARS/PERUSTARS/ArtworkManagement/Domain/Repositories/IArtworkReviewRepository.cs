using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Domain.Repositories
{
    public interface IArtworkReviewRepository : IBaseRepository<ArtworkReview>
    {
        Task<ArtworkReview> FindArtworkReviewByHobbyistIdAndArtworkIdAsync(long hobbyistId, long artworkId);
    }
}
