using MediatR;
using Org.BouncyCastle.Math;
using PERUSTARS.DataAnalytics.Application.Commands;

namespace PERUSTARS.DataAnalytics.Application.Commands
{
    public class CollectEventLogDataCommand: IRequest<bool>
    {
        public BigInteger EventParticipationArtistId { get; set; }
        public BigInteger HobbyistId { get; set; }
    }
}
