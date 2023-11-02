using System.Collections.Generic;
using MediatR;


namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
 
        public class DeleteProfileArtistCommand: IRequest
        {

            public long ArtistId;
        }
        
        public class DeleteProfileHobbyistCommand : IRequest
        {
            public long HobbyistId;
        }
    
}