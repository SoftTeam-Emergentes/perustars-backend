using System;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}