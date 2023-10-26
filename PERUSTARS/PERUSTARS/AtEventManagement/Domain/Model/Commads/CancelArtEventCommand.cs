using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public record CancelArtEventCommand(ArtEventStatus status);
}
