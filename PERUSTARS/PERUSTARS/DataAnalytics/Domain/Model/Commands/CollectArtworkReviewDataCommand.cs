using MediatR;
using Org.BouncyCastle.Math;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using PERUSTARS.Domain.Models;

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
