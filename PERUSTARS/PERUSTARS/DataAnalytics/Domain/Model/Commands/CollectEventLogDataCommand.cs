using MediatR;
using Org.BouncyCastle.Math;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.DataAnalytics.Application.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using System.Collections.Generic;

namespace PERUSTARS.DataAnalytics.Application.Commands
{
    public class CollectEventLogDataCommand: IRequest<bool>
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public long Score { get; set; }
        public InteractionType InteractionType { get; set; } = InteractionType.EVENT_PARTICIPATION;


    }
}
