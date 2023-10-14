using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Threading.Tasks;

namespace PERUSTARS.Shared.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _baseDbContext;
        
        public UnitOfWork(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }
        public async Task CompleteAsync()
        {
            await _baseDbContext.SaveChangesAsync();
        }
    }
}
