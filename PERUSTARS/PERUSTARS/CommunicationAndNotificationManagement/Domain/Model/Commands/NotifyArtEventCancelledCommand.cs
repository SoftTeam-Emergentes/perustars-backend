﻿using System;
using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyArtEventCancelledCommand : IRequest<bool>
    {
        public string Title { get; set; } //ArtEventTitle
        public string Description { get; set; } //ArtEventDescription
        public Location Location { get; set; } //ArtEventLocation
        public DateTime StartDate { get; set; } //ArtEventStartDate
        public DateTime EndDate { get; set; } //ArtEventEndDate
        public ArtEventStatus CurrentStatus { get; set; } //ArtEventStatus
    }
    
}