using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using System.Collections.Generic;

namespace PERUSTARS.ProfileManagement.Domain.Model.Queries
{
    public class GetAllFollowersByArtistQuery : IRequest<IEnumerable<Follower>>
    {
        public long ArtistId { get; set; }
    }
}
