using MediatR;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Commads
{
    public class DeleteParticipantCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
