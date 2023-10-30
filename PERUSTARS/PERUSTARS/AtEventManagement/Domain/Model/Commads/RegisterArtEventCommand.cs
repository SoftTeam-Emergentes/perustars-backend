using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public record RegisterArtEventCommand(string title,string description,DateTime StartDatetime, Location location,bool isOnline,long artistId,ArtEventStatus status);

}
