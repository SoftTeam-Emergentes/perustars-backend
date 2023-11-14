using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class FinishArtEventCommand:IRequest<string> { 
        public int artEventId { get; set; }
    }

}
