using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public record EditArtEventCommand(string title, string description,Location location,bool isOnline);
 
}
