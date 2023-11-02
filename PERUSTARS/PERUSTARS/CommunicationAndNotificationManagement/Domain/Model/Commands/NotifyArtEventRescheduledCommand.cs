using System;
using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyArtEventRescheduledCommand : IRequest<bool>
    {
        public string Title { get; set; } //ArtEventTitle
        public string Description { get; set; } //ArtEventDescription
        public Location location { get; set; } //ArtEventLocation
        public DateTime StartDate { get; set; } //ArtEventStartDate
        public ArtEventStatus CurrentStatus { get; set; } //ArtEventStatus
    }
}
