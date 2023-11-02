using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Domain.Repositories
{
    public interface IHobbyistFavoriteArtworkRepository : IBaseRepository<HobbyistFavoriteArtwork>
    {
        Task<HobbyistFavoriteArtwork> FindHobbyistFavoriteArtworkByHobbyistIdAndArtworkIdAsync(long hobbyistId, long artworkId);
    }
}