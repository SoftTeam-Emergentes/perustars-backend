
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Domain.Repositories
{
    public interface IHobbyistRepository:IBaseRepository<Hobbyist>
    {
        Task<Hobbyist> GetHobbyistByIdAsync(long hobbyistId);

        Task<bool> DeleteHobbyistProfileAsync(Hobbyist hobbyist);
    }
}