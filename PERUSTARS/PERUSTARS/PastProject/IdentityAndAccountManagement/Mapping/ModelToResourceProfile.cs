using AutoMapper;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Resources;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}