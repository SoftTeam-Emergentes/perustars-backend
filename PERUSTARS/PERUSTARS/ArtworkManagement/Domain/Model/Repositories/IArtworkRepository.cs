using System.Collections.Generic;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Repositories
{
    public interface IArtworkRepository : IBaseRepository<Artwork>
    {
        
    }
}
