﻿﻿using System;
using MediatR;
 using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;

 namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyArtEventRescheduledCommand : IRequest<bool>
    {
        public string Title { get; set; } //ArtEventTitle
        public string Description { get; set; } //ArtEventDescription
        public Location Location { get; set; } //ArtEventLocation
        public DateTime StartDate { get; set; } //ArtEventStartDate
        public ArtEventStatus CurrentStatus { get; set; } //ArtEventStatus
    }
}