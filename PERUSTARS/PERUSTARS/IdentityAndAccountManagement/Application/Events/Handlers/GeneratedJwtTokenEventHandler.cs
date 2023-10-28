using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Events.Handlers;

public class GeneratedJwtTokenEventHandler: INotificationHandler<GeneratedJwtTokenEvent>
{
    

    public GeneratedJwtTokenEventHandler()
    {
        
    }
    
    public async Task Handle(GeneratedJwtTokenEvent notification, CancellationToken cancellationToken)
    {
        return;
    }
}