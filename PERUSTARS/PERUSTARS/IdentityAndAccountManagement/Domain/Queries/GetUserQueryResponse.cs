using System.Numerics;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Queries;

public class GetUserQueryResponse
{
    public BigInteger UserId { get; set; }
    public string FirstName { get; set; }
}