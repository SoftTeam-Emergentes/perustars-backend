using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services.Communications;
using PERUSTARS.IdentityAndAccountManagement.Resources;

namespace PERUSTARS.IdentityAndAccountManagement.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}