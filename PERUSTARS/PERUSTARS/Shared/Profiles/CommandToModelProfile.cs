using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;

namespace PERUSTARS.Shared.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            CreateMap<RegisterUserCommand, User>();
        }
    }
}

