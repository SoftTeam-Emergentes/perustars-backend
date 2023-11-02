using AutoMapper;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;

namespace PERUSTARS.Shared.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            CreateMap<RegisterUserCommand, User>();
            CreateMap<RegisterProfileArtistCommand, Artist>();
            CreateMap<RegisterProfileHobbyistCommand, Hobbyist>();
            CreateMap<EditProfileArtistCommand, Artist>();
            CreateMap<EditProfileHobbyistCommand, Hobbyist>();
            CreateMap<DeleteProfileArtistCommand, Artist>();
            CreateMap<DeleteProfileHobbyistCommand, Hobbyist>();
            CreateMap<FollowArtistCommand, Follower>();
            CreateMap<UploadArtworkCommand, Artwork>();
            CreateMap<EditArtworkCommand, Artwork>();
            CreateMap<DeleteArtworkCommand, Artwork>();
            CreateMap<PurchaseArtworkCommand, Artwork>();
            CreateMap<RecommendArtworkCommand, ArtworkRecommendation>();
            CreateMap<ReviewArtworkCommand, ArtworkReview>();
            CreateMap<AssignFavoriteArtworkCommand, HobbyistFavoriteArtwork>();
            CreateMap<FollowArtistCommand, Follower>();
        }
    }
}

