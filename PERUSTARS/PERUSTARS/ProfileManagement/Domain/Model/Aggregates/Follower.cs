using System;
using System.Collections.Generic;

namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Follower
    {
        public long FollowerId { get; set; }
        public Hobbyist Hobbyist { get; set; }
        public long HobbyistId { get; set; }

        public Artist Artist { get; set; }
        public long ArtistId { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public bool Collected  { get; set; } = false;
    }
}