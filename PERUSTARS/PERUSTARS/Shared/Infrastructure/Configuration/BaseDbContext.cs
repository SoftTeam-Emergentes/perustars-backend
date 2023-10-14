using Microsoft.EntityFrameworkCore;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public abstract class BaseDbContext: DbContext
    {
        public BaseDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
    }
}
