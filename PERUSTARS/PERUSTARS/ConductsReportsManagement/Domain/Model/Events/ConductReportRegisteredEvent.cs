using MediatR;

namespace PERUSTARS.ConductsReportsManagement.Domain.Model.Events
{
    public class ConductReportRegisteredEvent : INotification
    {
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
    }
}
