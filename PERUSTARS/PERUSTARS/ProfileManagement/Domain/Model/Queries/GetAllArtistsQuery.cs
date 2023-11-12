using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using System.Collections.Generic;

namespace PERUSTARS.ProfileManagement.Domain.Model.Queries
{
    public class GetAllArtistsQuery: IRequest<IEnumerable<Artist>>
    {
    }
}
