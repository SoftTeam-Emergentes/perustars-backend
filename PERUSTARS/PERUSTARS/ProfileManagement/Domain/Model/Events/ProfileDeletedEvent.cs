using MediatR;

namespace PERUSTARS.ProfileManagement.Domain.Model.Events
{
    public class ProfileDeletedEvent: INotification
    {
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
    }
}