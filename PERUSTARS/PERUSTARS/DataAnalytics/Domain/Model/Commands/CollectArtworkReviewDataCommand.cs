using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectArtworkReviewDataCommand: IRequest<bool>
    {
        public long HobbyistId { get; }
        public long ArtistId { get; }
        public long Score { get; }
        public InteractionType InteractionType { get; } = InteractionType.ARTWORK_REVIEW;
    }
}
