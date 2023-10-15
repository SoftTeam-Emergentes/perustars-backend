using System;

namespace PERUSTARS.IdentityAndAccountManagement.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}