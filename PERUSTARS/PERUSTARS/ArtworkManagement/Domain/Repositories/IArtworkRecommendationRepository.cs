using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Domain.Repositories
{
    public interface IArtworkRecommendationRepository : IBaseRepository<ArtworkRecommendation>
    {
        Task<ArtworkRecommendation> FindArtworkRecommendationByHobbyistIdAndArtistIdAndArtworkIdAsync(long hobbyistId, long artistId, long artworkId);
    }
}
