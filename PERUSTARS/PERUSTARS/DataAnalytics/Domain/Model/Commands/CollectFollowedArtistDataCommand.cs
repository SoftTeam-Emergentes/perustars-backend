using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectFollowedArtistDataCommand : IRequest<bool>
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public long Score { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}
