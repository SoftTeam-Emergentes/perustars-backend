using MediatR;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
    public class FollowArtistCommand: IRequest<Unit>
    {
        //public long FollowerId { get; set; }
        public long ArtistId { get; set; }
        
        public long HobbyistId { get; set; }
    }
}