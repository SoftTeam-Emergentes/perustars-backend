using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class EditArtEventCommand: IRequest<string> {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Location location { get; set; }
        public bool isOnline { get; set; }
    }
 
}
