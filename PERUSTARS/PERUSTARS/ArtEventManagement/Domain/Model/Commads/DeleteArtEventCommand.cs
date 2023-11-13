using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class DeleteArtEventCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
