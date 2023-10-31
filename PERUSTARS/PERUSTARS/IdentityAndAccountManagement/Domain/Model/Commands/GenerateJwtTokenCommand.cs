using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;

public class GenerateJwtTokenCommand : IRequest<string>
{
    public User User { get; set; }
}