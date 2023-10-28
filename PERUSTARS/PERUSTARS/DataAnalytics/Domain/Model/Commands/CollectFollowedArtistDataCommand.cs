using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectFollowedArtistDataCommand: IRequest<bool>
    {
        public long HobbyistId { get; }
        public long ArtistId { get; }
        public long Score { get; }
        public InteractionType InteractionType { get; } = InteractionType.FOLLOW;
    }
}
