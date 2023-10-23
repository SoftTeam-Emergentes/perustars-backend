using System;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}