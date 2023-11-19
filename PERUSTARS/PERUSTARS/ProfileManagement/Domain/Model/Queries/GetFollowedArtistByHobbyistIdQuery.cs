using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using System.Collections.Generic;

namespace PERUSTARS.ProfileManagement.Domain.Model.Queries
{
    public class GetFollowedArtistByHobbyistIdQuery:IRequest<IEnumerable<Artist>>
    {
        public long HobbyistId { get; set; }
    }
}
