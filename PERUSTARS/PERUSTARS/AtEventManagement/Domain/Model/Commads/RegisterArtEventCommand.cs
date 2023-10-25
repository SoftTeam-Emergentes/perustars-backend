using System;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public record RegisterArtEventCommand(string title,string description,DateTime StartDatetime,);

}
