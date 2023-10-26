﻿using System;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class ArtworkRecommendation
    {
        public long Id { get; set; }
        public long HobyistId { get; set; }
        public Hobbyist Hobbyist { get; set; }
        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
        public long ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
        public DateTime RecommendationDateTime { get; set; }
        public bool Collected { get; set; } = false;
    }
}
