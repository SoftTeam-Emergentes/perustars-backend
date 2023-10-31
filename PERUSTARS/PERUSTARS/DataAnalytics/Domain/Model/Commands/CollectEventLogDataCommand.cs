using System.Collections.Generic;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectEventLogDataCommand: IRequest<IEnumerable<ParticipantEventRegistration>>
    {

    }
}
