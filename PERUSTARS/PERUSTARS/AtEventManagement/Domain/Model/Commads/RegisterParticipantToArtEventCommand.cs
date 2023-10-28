using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.AtEventManagement.Domain.Model.Commads
{
    public class RegisterParticipantToArtEventCommand:IRequest<string>
    {
        public long hobbyistId { get; set; }
        public long artEventId { get; set; }
    }
}
