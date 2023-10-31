using MediatR;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;

public class ValidateJwtTokenQuery : IRequest<long?>
{
    public string Token { get; set; }
}