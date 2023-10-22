using System;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class ArtistRecommendation
    {
        public BigInteger Id { get; set; }
        public Hoby Hobyist { get; set; }
        public DateTime RecommendationDateTime { get; set; }
    }
}
