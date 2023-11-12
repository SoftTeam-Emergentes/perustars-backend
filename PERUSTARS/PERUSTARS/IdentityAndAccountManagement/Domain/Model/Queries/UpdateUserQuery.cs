using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using System.Collections.Generic;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries
{
    public class UpdateUserQuery : IRequest<KeyValuePair<string, long>>
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
