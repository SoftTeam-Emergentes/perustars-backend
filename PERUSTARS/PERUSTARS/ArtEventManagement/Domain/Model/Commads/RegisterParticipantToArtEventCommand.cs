using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class RegisterParticipantToArtEventCommand:IRequest<string>
    {
        public long hobbyistId { get; set; }
        public long artEventId { get; set; }
    }
}
