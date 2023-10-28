using System.Threading.Tasks;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ProfileManagement.Domain.Repositories
{
    public interface IArtistRepository:IBaseRepository<Artist>
    {
        bool ExistsByBrandName(string brandname);
        Task<Artist> FindByBrandNameAsync(string brandname);
    }
}