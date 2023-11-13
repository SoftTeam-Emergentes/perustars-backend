using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class StartArtEventCommand:IRequest<string> { 
        public int id { get; set; }
    };

}
