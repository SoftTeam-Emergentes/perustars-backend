using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class HobbyistResource
    {
        public long HobbyistId { get; set; }
        public int Age { get; set; }
    }
}