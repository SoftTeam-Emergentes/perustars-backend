using MediatR;
using PERUSTARS.Shared.Domain;
using System.Collections.Generic;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Aggregates
{
    public class DataAnalytic
    {
        public BigInteger? DataAnalyticId { get; set; }

        public BigInteger? HobbyistId { get; set; }
        public BigInteger? ReviewedArtworkArtistId { get; set; }
        public BigInteger? FollowedArtistId { get; set; }
        public BigInteger? EventParticipationArtistId   { get; set; }

        public DataAnalytic(BigInteger? dataAnalyticId, BigInteger? hobbyistId, BigInteger? reviewedArtworkArtistId, BigInteger? followedArtistId, BigInteger? eventParticipationArtistId)
        {
            DataAnalyticId = dataAnalyticId;
            HobbyistId = hobbyistId;
            ReviewedArtworkArtistId = reviewedArtworkArtistId;
            FollowedArtistId = followedArtistId;
            EventParticipationArtistId = eventParticipationArtistId;
        }
    }
}
