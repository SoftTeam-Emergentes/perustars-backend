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
        public ArtistRepository(AppDbContext dbContext): base(dbContext){}

        public bool ExistsByBrandName(string brandname)
        {
            return _dbContext.Artists.Any(a => a.BrandName == brandname);
        }

        public Task<Artist> FindByBrandNameAsync(string brandname)
        {
            return _dbContext.Artists.SingleOrDefaultAsync(a =>a.BrandName ==brandname);
        }
    }
}