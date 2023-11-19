using MediatR;

namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
    public class DeleteFollower:IRequest<string>
    {
        public long HobbyistId { get; set; }
    }
}
