using System;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtEventManagement.Domain.Model.domainevents
{
    public class ArtEventCancelledEvent:INotification
    {
        public string Title { set; get; }
        public string Description { set; get; }
        public Location Location { set; get; }
        public DateTime StartDate { get; set; } //ArtEventStartDate
        public DateTime EndDate { get; set; } //ArtEventEndDate
        public ArtEventStatus CurrentStatus { get; set; }
    }
}
