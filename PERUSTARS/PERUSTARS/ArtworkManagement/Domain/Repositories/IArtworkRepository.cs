using System.Threading.Tasks;
using System.Collections.Generic;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Domain.Repositories
{
    public interface IArtworkRepository : IBaseRepository<Artwork>
    {
        Task<IEnumerable<Artwork>> FindAllArtworksByArtistIdAsync(long artistId);
        Task<IEnumerable<Artwork>> FindAllArtworksByTitleAsync(string title);
        Task<Artwork> FindArtworkByIdAsync(long artworkId);
        Task<Artwork> FindArtworkByArtistIdAndTitleAsync(long artistId, string title);
        Task<bool> RemoveArtworkAsync(Artwork artwork);
    }
}
