using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Infrastructure.Repositories
{
    public class ArtworkRepository : BaseRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Artwork>> FindAllArtworksByArtistIdAsync(long artistId)
        {
            return await _dbContext.Artworks.Where(art => art.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Artwork>> FindAllArtworksByTitleAsync(string title)
        {
            return await _dbContext.Artworks.Where(art => art.Title == title).ToListAsync();
        }

        public Task<Artwork> FindArtworkByArtistIdAndTitleAsync(long artistId, string title)
        {
            return _dbContext.Artworks.FirstOrDefaultAsync(art => art.ArtistId == artistId && art.Title == title);
        }

        public async Task<Artwork> FindArtworkByIdAsync(long artworkId)
        {
            return await _dbContext.Artworks.FirstOrDefaultAsync(art => art.Id == artworkId);
        }

        public async Task<bool> RemoveArtworkAsync(Artwork artwork)
        {
            try
            {
                if (artwork != null)
                {
                    _dbContext.Artworks.Remove(artwork);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error removing artwork");
            }
        }
    }
}
