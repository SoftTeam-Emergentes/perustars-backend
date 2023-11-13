using MediatR;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class DeleteParticipantCommand:IRequest<string>
    {
        public int id { get; set; }
    }
}
