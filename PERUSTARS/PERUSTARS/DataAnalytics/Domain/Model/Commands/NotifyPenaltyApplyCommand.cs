using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class NotifyPenaltyApplyCommand: IRequest<bool>
    {
        public long HobbyistId { get; }
        public long ArtistId { get; }
        public long Score { get; }
        public InteractionType InteractionType { get; } = InteractionType.CONDUCT_REPORT;
    }
}
