using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class CancelArtEventCommand:IRequest<string>{
        public int id { get; set; }
    }
}
