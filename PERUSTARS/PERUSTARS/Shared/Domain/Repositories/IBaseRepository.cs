using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace PERUSTARS.Shared.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindByIdAsync(long id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
