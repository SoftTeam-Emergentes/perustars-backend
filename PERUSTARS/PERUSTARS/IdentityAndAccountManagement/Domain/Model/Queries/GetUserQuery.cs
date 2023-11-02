using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;


namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries
{
    public class GetUserQuery : IRequest<UserResource>
    {
        public long? UserId { get; set; }
    }
}

