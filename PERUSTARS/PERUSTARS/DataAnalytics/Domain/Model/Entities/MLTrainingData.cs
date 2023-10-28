using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using System;

namespace PERUSTARS.DataAnalytics.Domain.Model.Entities
{
    public class MLTrainingData
    {
        public long Score { get; set; }
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public InteractionType InteractionType { get; set; }
    }
}
