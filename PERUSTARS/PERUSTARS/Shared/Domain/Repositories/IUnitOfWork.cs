using System.Threading.Tasks;

namespace PERUSTARS.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
