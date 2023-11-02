
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;


namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Hobbyist 
    {
        public long HobbyistId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("User")]
        public long UserId { get; set; }
        public int Age { get; set; }
        //public List<Interest> Interests { get; set; }
        public List<Follower> FollowedArtists { get; set; }
        
        public bool Collected  { get; set; } = false;
        public IEnumerable<Participant> Participants { get; set; }
        //public List<EventAssistance> Assistance { get; set; }
        
        /*public Hobbyist(long hobbyistId, User user, long userId, int age, List<Follower> followedArtists,  bool collected)
        {
            HobbyistId = hobbyistId;
            User = user;
            UserId = userId;
            Age = age;
            FollowedArtists = followedArtists;
            Collected = collected;
        }*/
        public Hobbyist(){}
       
    }
}