
using MediatR;

namespace PERUSTARS.ProfileManagement.Domain.Model.Events
{
    public class ProfileRegisteredEvent: INotification
    {
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
        
    }
}