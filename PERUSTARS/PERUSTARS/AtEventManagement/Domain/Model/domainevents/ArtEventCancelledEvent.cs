using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System;

namespace PERUSTARS.AtEventManagement.Domain.Model.domainevents
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
