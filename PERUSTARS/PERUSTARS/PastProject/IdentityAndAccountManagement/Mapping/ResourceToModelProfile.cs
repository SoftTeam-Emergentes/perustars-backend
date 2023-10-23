using AutoMapper;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(options => options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && 
                            string.IsNullOrEmpty((string) property)) return false;
                        return true;
                    }));
        }
    }
}