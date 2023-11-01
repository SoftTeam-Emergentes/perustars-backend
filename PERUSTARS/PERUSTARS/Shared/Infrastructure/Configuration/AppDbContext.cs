using Microsoft.EntityFrameworkCore;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Extensions;
using System;

using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;

namespace PERUSTARS.Shared.Infrastructure.Configuration


{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParticipantEventRegistration> ParticipantEventRegistrations { get; set; }
        public DbSet<ArtworkRecommendation> ArtistRecommendations { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ArtEvent> Events { get; set; }
        public DbSet<Participant> EventAssistances { get; set; }
        public DbSet<Notification> Notifications { get; set; }
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

            //---Users---
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
     
            builder.Entity<Artist>().ToTable("Artists");
            
            builder.Entity<Artist>()
                    .HasOne(a => a.User)
                    .WithOne()
                    .HasForeignKey<Artist>(a => a.ArtistId);
            builder.Entity<Artist>().Property(a => a.Age);
            builder.Entity<Artist>().Property(a => a.Followers);
            builder.Entity<Artist>().Property(a => a.User);
            builder.Entity<Artist>().Property(a => a.Description);
            builder.Entity<Artist>().Property(a => a.Genre);
            builder.Entity<Artist>().Property(a => a.Phrase);
            builder.Entity<Artist>().Property(a => a.BrandName).HasMaxLength(50);
            builder.Entity<Artist>().Property(a => a.ContactEmail).HasMaxLength(80);
            builder.Entity<Artist>().Property(a => a.ContactNumber);
            builder.Entity<Artist>().Property(a => a.SocialMediaLink).HasMaxLength(255);
            builder.Entity<Artist>().Property(a => a.Collected).HasDefaultValue(false);
            

            builder.Entity<Hobbyist>().ToTable("Hobbyists");
            builder.Entity<Hobbyist>().HasKey(a => a.HobbyistId);
            builder.Entity<Hobbyist>().Property(a => a.HobbyistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hobbyist>().Property(a => a.Age);
            //builder.Entity<Hobbyist>().HasCheckConstraint("Age <= 120");
            builder.Entity<Hobbyist>().Property(a => a.User);
            builder.Entity<Hobbyist>().Property(a => a.Followers);
            builder.Entity<Hobbyist>().Property(a => a.Collected).HasDefaultValue(false);
            
                    
            builder.Entity<Hobbyist>()
                    .HasOne(u => u.User)
                    .WithOne()
                    .HasForeignKey<Hobbyist>(u => u.HobbyistId);

            builder.Entity<Hobbyist>()
                    .HasMany(h => h.Followers)
                    .WithOne(h => h.Hobbyist)
                    .HasForeignKey(h => h.HobbyistId);

            builder.Entity<Artist>()
                    .HasMany(a => a.Followers)
                    .WithOne(a => a.Artist)
                    .HasForeignKey(a => a.ArtistId);

            builder.Entity<Follower>().ToTable("Followers");
            builder.Entity<Follower>().Property(f => f.Hobbyist);
            builder.Entity<Follower>().Property(f => f.Artist);
            builder.Entity<Follower>().Property(f => f.ArtistId);
            builder.Entity<Follower>().Property(f => f.HobbyistId);
            builder.Entity<Follower>().Property(a => a.RegistrationDate);
            builder.Entity<Follower>().Property(a => a.Collected).HasDefaultValue(false);
            

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
            
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Participant>().HasKey(p => p.Id);
            builder.Entity<Participant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Participant>().Property(p => p.UserName).IsRequired();
            builder.Entity<Participant>().Property(p=>p.RegisterDateTime).IsRequired();
            builder.Entity<Participant>().Property(p=>p.CheckInDateTime).IsRequired();
            builder.Entity<Participant>().Property(p=>p.ParticipantRegistrationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<Participant>().Property(p => p.Collected).HasDefaultValue(false).IsRequired();
            builder.Entity<Participant>()
                .HasOne(p => p.Hobyst)
                .WithMany(h => h.Participants)
                .HasForeignKey(p => p.HobbyistId);

            builder.Entity<ArtEvent>()
                .HasOne(ae => ae.Artist)
                .WithMany(ar => ar.ArtEvents)
                .HasForeignKey(ae => ae.ArtistId);
            builder.Entity<ArtEvent>()
                .HasMany(ae => ae.Participants)
                .WithOne(p => p.ArtEvent)
                .HasForeignKey(p => p.ArtEventId);
            //builder.Entity<Event>().ToTable("events");
            //builder.Entity<Event>().HasKey(e => e.EventId);
            //builder.Entity<Event>().Property(e=>e.EventId).IsRequired().ValueGeneratedOnAdd();
            
            #region ParticipantEventRegistrations

            builder.Entity<ParticipantEventRegistration>().ToTable("ParticipantEventRegistrations");
            builder.Entity<ParticipantEventRegistration>().HasKey(p => p.Id);
            builder.Entity<ParticipantEventRegistration>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.EventTitle).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.ArtistId).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.HobyistId).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.RegistrationDate).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ParticipantEventRegistration>().Property(p => p.Collected).HasDefaultValue(false).IsRequired();

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
            builder.Entity<Artwork>().Property(a => a.LikedHobbyistsList).IsRequired();
            builder.Entity<Artwork>().Property(a => a.CoverImage.Content).HasColumnName("CoverImageContent").IsRequired();
            builder.Entity<Artwork>().Property(a => a.CoverImage.Format).HasColumnName("CoverImageFormat").IsRequired();
            builder.Entity<Artwork>().Property(a => a.ReviewsList).IsRequired();
            builder.Entity<Artwork>().Property(a => a.PublishedAt).IsRequired();
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


            #region Notifications
            // -------CommunicationAndNotificationManagement Bounded Context--------
            
            builder.Entity<Notification>().ToTable("Notifications");
            builder.Entity<Notification>().HasKey(n => n.Id);
            builder.Entity<Notification>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Notification>().Property(n => n.Title).IsRequired();
            builder.Entity<Notification>().Property(n => n.Description);
            builder.Entity<Notification>().Property(n => n.ArtistId).IsRequired();
            builder.Entity<Notification>().Property(n => n.HobbyistId).IsRequired();
            builder.Entity<Notification>().Property(n => n.Collected).HasDefaultValue(false).IsRequired();
            builder.Entity<Notification>().Property(n => n.Sender).IsRequired(); 
            builder.Entity<Notification>().Property(n => n.SentAt).IsRequired(); 
            builder.Entity<Notification>().Property(n => n.IsRead).HasDefaultValue(false).IsRequired();
            
            #endregion



            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
