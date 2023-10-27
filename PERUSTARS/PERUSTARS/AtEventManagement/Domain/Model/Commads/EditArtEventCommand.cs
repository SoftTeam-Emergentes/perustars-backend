using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class EditArtEventCommand: IRequest<string> {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Location location { get; set; }
        public bool isOnline { get; set; }
    }
 
}
