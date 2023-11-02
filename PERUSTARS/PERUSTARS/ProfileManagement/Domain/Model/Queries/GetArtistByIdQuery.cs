using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Model.Queries
{
    public class GetArtistByIdQuery : IRequest<GetArtistFollowers>
    {
        public long ArtistId { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }

        [ForeignKey("Follower")]
        public List<Follower> FollowersArtist { get; set; }

        public bool Collected { get; set; } = false;
    }
}

