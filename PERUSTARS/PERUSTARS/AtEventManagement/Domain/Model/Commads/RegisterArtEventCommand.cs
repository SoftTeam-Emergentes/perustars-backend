using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class RegisterArtEventCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public Location Location { get; set; }
        public bool? IsOnline { get; set; }
        public long ArtistId { get; set; }
        public ArtEventStatus CurrentStatus { get; set; }
        public bool Collected { get; set; }
    }

}
