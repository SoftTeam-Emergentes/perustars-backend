using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Events
{
    public class ArtworkEditedEvent : INotification
    {
        public long Id { get; set; }

    }
}
