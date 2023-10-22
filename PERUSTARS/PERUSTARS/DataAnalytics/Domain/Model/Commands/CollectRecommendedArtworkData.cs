using System;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Commands
{
    public class CollectRecommendedArtworkData
    {
        public BigInteger Id;
        public BigInteger HobyistId;
        public BigInteger RecommededArtistId;
        public DateTime RecommendationDateTime;
    }
}
