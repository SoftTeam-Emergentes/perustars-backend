using AutoMapper;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Interface.ACL.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ACLResourceToCommandProfile : Profile
    {
        public ACLResourceToCommandProfile()
        {
            CreateMap<DataAnalyticACLResource, CollectArtworkReviewDataCommand>();
            CreateMap<DataAnalyticACLResource, CollectEventLogDataCommand>();
            CreateMap<DataAnalyticACLResource, CollectFollowedArtistDataCommand>();
            CreateMap<DataAnalyticACLResource, CollectPenaltyAppliedDataCommand>();
        }
    }
}
