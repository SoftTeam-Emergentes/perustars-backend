using System.Numerics;
using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Queries;

public class GetUserQuery: IRequest<GetUserQueryResponse>
{
    public BigInteger UserId { get; set; }
}