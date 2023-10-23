using MediatR;
using System.Numerics;

namespace PERUSTARS.DataAnalytics.Domain.Model.Events
{
    public class EventLogDataCollectedEvent: INotification
    {
        public BigInteger EventParticipationArtistId { get; set; }
        public BigInteger HobbyistId { get; set; }
    }
}
