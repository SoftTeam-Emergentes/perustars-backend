using System;
using System.Collections.Generic;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtEventManagement.Interfaces.REST.Resources;

public class ArtEventResource
{
    public long? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? StartDateTime { get; set; }
    public Location Location { get; set; }
    public bool? IsOnline { get; set; }
    public long? ArtistId { get; set; }
    public string? CurrentStatus { get; set; }
    public IEnumerable<Participant> Participants { get; set; }
    public bool Collected { get; set; }
}