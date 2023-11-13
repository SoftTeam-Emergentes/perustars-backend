

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class HobbyistResource
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public long HobbyistId { get; set; }
        
        public int Age { get; set; }
        public List<FollowerHobbyistResource> FollowedArtists { get; set; }
    }
}