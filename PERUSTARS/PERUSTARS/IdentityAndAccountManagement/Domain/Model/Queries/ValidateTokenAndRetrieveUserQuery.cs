using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries
{
    public class ValidateTokenAndRetrieveUserQuery : IRequest<User>
    {
        public string Token { get; set; }
    }
}


