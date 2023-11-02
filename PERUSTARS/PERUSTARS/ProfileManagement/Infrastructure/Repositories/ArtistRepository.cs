using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.ProfileManagement.Infrastructure.Repositories
{
    public class ArtistRepository:BaseRepository<Artist>, IArtistRepository
    
    {
        public ArtistRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public bool ExistsByBrandName(string brandname)
        {
            return _dbContext.Artists.Any(a => a.BrandName == brandname);
        }

        public Task<Artist> FindByBrandNameAsync(string brandname)
        {
            return _dbContext.Artists.SingleOrDefaultAsync(a =>a.BrandName ==brandname);
        }

        public Task<Artist> GetArtistByIdAsync(long artistId)
        {
            try
            {
                return _dbContext.Artists.SingleOrDefaultAsync(a => a.ArtistId == artistId);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error getting artist by id",ex);
            }
        }

        public async Task<bool> DeleteArtistProfileAsync(Artist artist)
        {
            try
            {
                if (artist != null)
                {
                    _dbContext.Artists.Remove(artist);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting artist profile",e);
            }
        }
    }
}