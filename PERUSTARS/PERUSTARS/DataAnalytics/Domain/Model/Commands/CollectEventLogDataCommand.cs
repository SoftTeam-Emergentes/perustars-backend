using MediatR;
using Org.BouncyCastle.Math;
using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Collections.Generic;

namespace PERUSTARS.DataAnalytics.Application.Commands
{
    public class CollectEventLogDataCommand: IRequest<IEnumerable<ParticipantEventRegistration>>
    {

    }
}
