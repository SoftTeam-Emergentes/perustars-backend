<<<<<<< HEAD
﻿using System.Numerics;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model;

public class User
{
    public BigInteger UserId { get; set; }
    public string FirstName { get; set; }
}
=======
﻿using PERUSTARS.ProfileManagement.Domain.Model.Entities;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public Artist Artist { get; set; }
        public Hobbyist Hobbyist { get; set; }
        
        
    }
}
>>>>>>> 4d9ba90a405a7e71f7d002c1ccb2e60db6e729a2
