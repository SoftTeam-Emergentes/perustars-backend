﻿using System.Numerics;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model;

public class User
{
    public BigInteger UserId { get; set; }
    public string FirstName { get; set; }
}