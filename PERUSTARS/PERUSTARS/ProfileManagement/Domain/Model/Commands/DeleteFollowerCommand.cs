using MediatR;

namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
    public class DeleteFollowerCommand:IRequest<string>
    {
        public long HobbyistId { get; set; }
    }
}
