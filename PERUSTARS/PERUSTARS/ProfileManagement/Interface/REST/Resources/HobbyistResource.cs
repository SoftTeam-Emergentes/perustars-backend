using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class HobbyistResource
    {
        public BigInteger HobbyistId { get; set; }
        public List<Follower> Followers { get; set; }
    }
}