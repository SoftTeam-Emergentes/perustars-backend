using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;

using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

using PERUSTARS.Shared.Extensions;
using System;

using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;


namespace PERUSTARS.Shared.Infrastructure.Configuration


{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParticipantEventRegistration> ParticipantEventRegistrations { get; set; }
        public DbSet<ArtistArtworkRecommendation> ArtistRecommendations { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<ArtEvent> Events { get; set; }
        public DbSet<Participant> EventAssistances { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
            
            

            builder.Entity<Hobbyist>().ToTable("Hobbyists");
            builder.Entity<Hobbyist>().HasKey(a => a.HobbyistId);
            builder.Entity<Hobbyist>().Property(a => a.HobbyistId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hobbyist>().Property(a => a.Age);
            //builder.Entity<Hobbyist>().HasCheckConstraint("Age <= 120");
            builder.Entity<Hobbyist>().Property(a => a.User);
            builder.Entity<Hobbyist>().Property(a => a.Followers);
            
                    
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
            

            builder.Entity<ArtEvent>().ToTable("ArtEvents");
            builder.Entity<ArtEvent>().HasKey(a => a.Id);
            builder.Entity<ArtEvent>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtEvent>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.ArtEvents)
                .HasForeignKey(a => a.ArtistId);
            builder.Entity<ArtEvent>()
                .HasMany(a => a.Participants)
                .WithOne(p => p.ArtEvent)
                .HasForeignKey(p => p.ArtEventId);
            builder.Entity<Participant>().ToTable("Participants");
            builder.Entity<Participant>().HasKey(p => p.Id);
            builder.Entity<Participant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Participant>()
                .HasOne(p => p.Hobyst)
                .WithMany(h => h.Participants)
                .HasForeignKey(p => p.HobystId);


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

            #region ArtistRecommendations

            builder.Entity<ArtistArtworkRecommendation>().ToTable("ArtistRecommendations");
            builder.Entity<ArtistArtworkRecommendation>().HasKey(ar => ar.Id);
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.ArtistId).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.HobyistId).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.RecommendationDateTime).HasColumnType("timestamp").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Entity<ArtistArtworkRecommendation>().Property(ar => ar.Collected).HasDefaultValue(false).IsRequired();

            #endregion


            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
