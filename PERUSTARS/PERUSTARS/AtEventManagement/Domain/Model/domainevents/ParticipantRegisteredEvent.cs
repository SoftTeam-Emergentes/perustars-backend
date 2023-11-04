using MediatR;

namespace PERUSTARS.AtEventManagement.Domain.Model.domainevents
{
    public class ParticipantRegisteredEvent: INotification
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
    }
}
