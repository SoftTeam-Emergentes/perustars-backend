using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Domain.Repositories
{
    public interface IArtistArtworkRecommendationRepository: IBaseRepository<ArtistRecommendation>
    {
        Task<IEnumerable<ArtistRecommendation>> GetAllNotCollectedArtistRecommendationsAsync();
    }
}
