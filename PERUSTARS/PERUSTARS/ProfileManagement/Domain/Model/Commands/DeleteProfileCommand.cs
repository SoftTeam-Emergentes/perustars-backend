using System.Collections.Generic;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
    public class DeleteProfileCommand
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
}