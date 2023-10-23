using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ResourceToCommand: Profile
    {
        public ResourceToCommand()
        {
            CreateMap<RegisterUserRequest, RegisterUserCommand>();
        }
    }
}
