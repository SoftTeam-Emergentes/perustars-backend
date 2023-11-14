using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtEventManagement.Interfaces.REST.Resources;

public class UpdateArtEventResource
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Location location { get; set; }
    public bool isOnline { get; set; }
}