using System.Numerics;
using MediatR;

namespace PERUSTARS.ProfileManagement.Domain.Model.Events
{
    public class ProfileRegisteredEvent: INotification
    {
        public BigInteger ArtistId { get; set; }
        public BigInteger HobbyistId { get; set; }
        
    }
}