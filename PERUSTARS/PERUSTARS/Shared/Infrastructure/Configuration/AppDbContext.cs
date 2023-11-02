using Microsoft.EntityFrameworkCore;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Extensions;
using System;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.Shared.Infrastructure.Configuration
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArtworkRecommendation> ArtistRecommendations { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ConductReport> ConductReports { get; set; }
        public DbSet<ArtEvent> Events { get; set; }
        public DbSet<Participant> EventAssistances { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtworkRecommendation> ArtworkRecommendations { get; set; }
        public DbSet<ArtworkReview> ArtworkReviews { get; set; }
        public DbSet<HobbyistFavoriteArtwork> HobbyistFavoriteArtworks { get; set; }
        public DbSet<ArtEvent> ArtEvents { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region ConductReports

            builder.Entity<ConductReport>().ToTable("ConductReport");
            builder.Entity<ConductReport>().HasKey(c => c.id);
            builder.Entity<ConductReport>().Property(c => c.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ConductReport>().Property(c => c.Title).IsRequired();
            builder.Entity<ConductReport>().Property(c => c.Description).IsRequired();
            builder.Entity<ConductReport>().Property(c => c.DateTimeReport);
            builder.Entity<ConductReport>().Property(c => c.HobbystId).IsRequired();

            #endregion


            #region Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<User>().Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.FirstName);
            builder.Entity<User>().Property(u => u.LastName).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            #endregion


            #region Followers

            builder.Entity<Follower>().ToTable("Followers");
            builder.Entity<Follower>().HasKey(f => f.Id);
            builder.Entity<Follower>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Follower>().Property(f => f.ArtistId);
            builder.Entity<Follower>().Property(f => f.HobbyistId);
            builder.Entity<Follower>().Property(a => a.RegistrationDate).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Follower>().Property(a => a.Collected).HasDefaultValue(false);

            #endregion


            #region Artists

            builder.Entity<Artist>().ToTable("Artists");
            builder.Entity<Artist>().HasKey(a => a.ArtistId);
            builder.Entity<Artist>().Property(a=>a.ArtistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Artist>().Property(a => a.Age);
            builder.Entity<Artist>().Property(a => a.Description);
            builder.Entity<Artist>().Property(a => a.Genre).HasConversion<string>();
            builder.Entity<Artist>().Property(a => a.Phrase);
            builder.Entity<Artist>().Property(a => a.BrandName).HasMaxLength(50);
            builder.Entity<Artist>().Property(a => a.ContactEmail).HasMaxLength(80);
            builder.Entity<Artist>().Property(a => a.ContactNumber);
            builder.Entity<Artist>().Property(a => a.Collected).HasDefaultValue(false);

            // RelationShips
            builder.Entity<Artist>()
                   .HasOne(a => a.User)
                   .WithOne()
                   .HasForeignKey<Artist>(a => a.UserId);

            builder.Entity<Artist>()
                    .HasMany(a => a.Followers)
                    .WithOne(f => f.Artist)
                    .HasForeignKey(f => f.ArtistId);

            #endregion


            #region Hobbyists

            builder.Entity<Hobbyist>().ToTable("Hobbyists");
            builder.Entity<Hobbyist>().HasKey(a => a.HobbyistId);
            builder.Entity<Hobbyist>().Property(a => a.HobbyistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hobbyist>().Property(a => a.Age);
            builder.Entity<Hobbyist>().Property(a => a.Collected).HasDefaultValue(false);

            // RelationShips
            builder.Entity<Hobbyist>()
                   .HasOne(h => h.User)
                   .WithOne()
                   .HasForeignKey<Hobbyist>(h => h.UserId);

            builder.Entity<Hobbyist>()
                    .HasMany(h => h.Followers)
                    .WithOne(f => f.Hobbyist)
                    .HasForeignKey(f => f.HobbyistId);

            #endregion


            #region Participants

            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Participant>().HasKey(p => p.Id);
            builder.Entity<Participant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Participant>().Property(p => p.UserName).IsRequired();
            builder.Entity<Participant>().Property(p => p.RegisterDateTime).IsRequired();
            builder.Entity<Participant>().Property(p => p.CheckInDateTime).IsRequired();
            builder.Entity<Participant>().Property(p => p.ParticipantRegistrationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<Participant>().Property(p => p.Collected).HasDefaultValue(false).IsRequired();

            // Relationships
            // builder.Entity<Participant>()//.Property(p => p.HobbyistId);
            //     .HasOne(p => p.Hobyst)
            //     .WithMany(h => h.Participants)
            //     .HasForeignKey(p => p.HobbyistId);

            #endregion


            #region ArtEvents


            builder.Entity<ArtEvent>().ToTable("ArtEvents");
            builder.Entity<ArtEvent>().HasKey(a => a.Id);
            builder.Entity<ArtEvent>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtEvent>().Property(a => a.Title).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.Description).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.StartDateTime).IsRequired();
            builder.Entity<ArtEvent>().OwnsOne(ae => ae.Location, location =>
            {
                location.Property(l => l.Country).IsRequired();
                location.Property(l => l.City).IsRequired();
                location.Property(l => l.Latitude).IsRequired();
                location.Property(l => l.Longitude).IsRequired();
            });
            builder.Entity<ArtEvent>().Property(a => a.IsOnline).IsRequired();
            builder.Entity<ArtEvent>().Property(a => a.CurrentStatus).HasConversion(v => v.ToString(), v => (ArtEventStatus)Enum.Parse(typeof(ArtEventStatus), v));
            builder.Entity<ArtEvent>().Property(a=>a.Collected).HasDefaultValue(false).IsRequired();

            // RelationShips
            builder.Entity<ArtEvent>()
               .HasOne(ae => ae.Artist)
               .WithMany(ar => ar.ArtEvents)
               .HasForeignKey(ae => ae.ArtistId);

            builder.Entity<ArtEvent>()
                .HasMany(ae => ae.Participants)
                .WithOne(p => p.ArtEvent)
                .HasForeignKey(p => p.ArtEventId);

            #endregion

            #region Artworks
            
            builder.Entity<Artwork>().ToTable("Artworks");
            builder.Entity<Artwork>().HasKey(a => a.Id);
            builder.Entity<Artwork>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Artwork>().Property(a => a.Title).IsRequired();
            builder.Entity<Artwork>().Property(a => a.Description).IsRequired();
            builder.Entity<Artwork>().Property(a => a.MainContent.Content).HasColumnName("MainContentContent").IsRequired();
            builder.Entity<Artwork>().Property(a => a.MainContent.Format).HasColumnName("MainContentFormat").IsRequired();
            builder.Entity<Artwork>().Property(a => a.Price).IsRequired();
            builder.Entity<Artwork>().Property(a => a.CoverImage.Content).HasColumnName("CoverImageContent").IsRequired();
            builder.Entity<Artwork>().Property(a => a.CoverImage.Format).HasColumnName("CoverImageFormat").IsRequired();
            builder.Entity<Artwork>().Property(a => a.PublishedAt).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<Artwork>().Property(a => a.Status).IsRequired();
            builder.Entity<Artwork>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.Artworks)
                .HasForeignKey(a => a.ArtistId);
            
            #endregion

            #region ArtworkRecommendations

            builder.Entity<ArtworkRecommendation>().ToTable("ArtworkRecommendations");
            builder.Entity<ArtworkRecommendation>().HasKey(ar => ar.Id);
            builder.Entity<ArtworkRecommendation>().Property(ar => ar.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtworkRecommendation>().Property(ar => ar.RecommendationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ArtworkRecommendation>().Property(ar => ar.Collected).HasDefaultValue(false).IsRequired();
            builder.Entity<ArtworkRecommendation>()
                .HasOne(ar => ar.Artist)
                .WithMany(a => a.ArtworkRecommendations)
                .HasForeignKey(ar => ar.ArtistId);
            builder.Entity<ArtworkRecommendation>()
                .HasOne(ar => ar.Hobbyist)
                .WithMany(h => h.ArtworkRecommendations)
                .HasForeignKey(ar => ar.HobyistId);
            builder.Entity<ArtworkRecommendation>()
                .HasOne(ar => ar.Artwork)
                .WithMany(a => a.ArtworkRecommendations)
                .HasForeignKey(ar => ar.ArtworkId);

            #endregion

            #region ArtworkReviews

            builder.Entity<ArtworkReview>().ToTable("ArtworkReviews");
            builder.Entity<ArtworkReview>().HasKey(a => a.Id);
            builder.Entity<ArtworkReview>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtworkReview>().Property(a => a.Title).IsRequired();
            builder.Entity<ArtworkReview>().Property(a => a.Comment).IsRequired();
            builder.Entity<ArtworkReview>().Property(a => a.ReviewDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ArtworkReview>().Property(a => a.Calification).IsRequired();
            builder.Entity<ArtworkReview>().Property(a => a.Collected).HasDefaultValue(false).IsRequired();
            builder.Entity<ArtworkReview>()
                .HasOne(a => a.Artwork)
                .WithMany(a => a.ReviewsList)
                .HasForeignKey(a => a.ArtworkId);
            builder.Entity<ArtworkReview>()
                .HasOne(a => a.Hobbyist)
                .WithMany(h => h.ArtworkReviews)
                .HasForeignKey(a => a.HobbyistId);

            #endregion

            #region HobbyistFavoriteArtworks

            builder.Entity<HobbyistFavoriteArtwork>().ToTable("HobbyistFavoriteArtworks");
            builder.Entity<HobbyistFavoriteArtwork>().HasKey(h => h.Id);
            builder.Entity<HobbyistFavoriteArtwork>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HobbyistFavoriteArtwork>()
                .HasOne(h => h.Hobbyist)
                .WithMany(h => h.FavoriteArtworks)
                .HasForeignKey(h => h.HobbyistId);
            builder.Entity<HobbyistFavoriteArtwork>()
                .HasOne(h => h.Artwork)
                .WithMany(a => a.LikedHobbyistsList)
                .HasForeignKey(h => h.ArtworkId);

            #endregion


            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
