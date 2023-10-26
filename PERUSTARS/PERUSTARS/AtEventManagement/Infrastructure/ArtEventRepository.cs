using Microsoft.EntityFrameworkCore;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Infrastructure
{
    public class ArtEventRepository :BaseRepository<ArtEvent>, IArtEventRepository
    {
        public ArtEventRepository(AppDbContext dbContext) : base(dbContext) { 
        }

        public new async Task AddAsync(ArtEvent entity)
        {
            await _dbContext.ArtEvents.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ArtEvent>> findByArtistIdAsync(int artistId)
        {
            return await _dbContext.ArtEvents.Where(a => a.ArtistId == artistId).ToListAsync();
        }

        public new async Task<ArtEvent> FindByIdAsync(int id)
        {
            return await _dbContext.ArtEvents.FindAsync(id);
        }

        public new async Task<IEnumerable<ArtEvent>> ListAsync()
        {
            return await _dbContext.ArtEvents.ToListAsync();
        }

        public new async void Remove(ArtEvent entity)
        {
            var artEvent=await _dbContext.ArtEvents.FindAsync(entity);
            if(artEvent!=null)
            {
                _dbContext.ArtEvents.Remove(artEvent);
                await _dbContext.SaveChangesAsync();
            }
        }

        public new async void Update(ArtEvent entity)
        {
            _dbContext.ArtEvents.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
