using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class EditArtEventCommand: IRequest<string> {
        string title { get; set; }
        string description { get; set; }
        Location location { get; set; }
        bool isOnline { get; set; }
    }
 
}
